using DoorControlDemo.Data;
using DoorControlDemo.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DoorControlDemo.ViewModels
{
    public class CreateBadgeViewModel : ViewModelBase
    {
        // Declare the database
        public readonly DoorControlDbContext dbContext;

        //Declare a MessageBoxDisplay
        private MessageBoxDisplay _messageBoxDisplay = new();

        // Set the constructor
        public CreateBadgeViewModel(DoorControlDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            CreateBadgeCommand = new RelayCommand(CreateBadge);
        }

        // Declare the Create User Command
        public ICommand CreateBadgeCommand { get; }


        // Declare a private field for the new value
        string _badgeId;
        // Set its new value
        public string BadgeId
        {
            get => _badgeId;
            set
            {
                _badgeId = value;
                OnPropertyChanged(nameof(BadgeId));
            }
        }

        public void CreateBadge()
        {
            /*// Check if required fields are empty
            if (Convert.ToInt32(BadgeId) == 0 ) // You can adjust this condition based on your specific requirements
            {
                //MessageBoxDisplay messageBoxDisplay = new();
                //messageBoxDisplay.DisplayMessage("Please fill in a valid Badge number.");
                //messageBoxDisplay.DisplayMessage("Please fill in a valid Badge number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show($"Please fill in a valid Badge number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Validation failed
            }*/

            //Create an instance of a badge
            Badge badge = new();

            // Check if a badge with the same BadgeId already exists in the database
            if (dbContext.Badges.Any(b => b.BadgeId == _badgeId))
            {
                _messageBoxDisplay.DisplayMessage("This badge already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            /*// Implement logic to create a Badge, perhaps by calling a method in your model
            Badge newBadge = new Badge
            {
                BadgeId = BadgeId,
            };*/

            var createdBadge = badge.createBadge(BadgeId);


            if (createdBadge is null)
            {
                _messageBoxDisplay.DisplayMessage(badge.Message);
                return;
            }

            if (string.IsNullOrEmpty(createdBadge.BadgeId))
            {
                _messageBoxDisplay.DisplayMessage(badge.Message);
                return;
            }

            // Add the badge to the context
            dbContext.Badges.Add(createdBadge);

            // Save changes to the database
            dbContext.SaveChanges();



            // Add additional logic as needed, e.g., validation, interaction with your data context
            // Construct a message string with information about all Badges
            StringBuilder badgesInfo = new StringBuilder("Badges in the database:\n");

            foreach (var b in dbContext.Badges)
            {
                badgesInfo.AppendLine($" BadgeID: {b.BadgeId}");
            }

            // Display the message with badge information
            MessageBox.Show($"Badge {createdBadge.BadgeId} created successfully!\n\n{badgesInfo.ToString()}");
        }


    }
}
