using DoorControlDemo.Data;
using DoorControlDemo.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoorControlDemo.ViewModels
{
    public class CreateBadgeViewModel : INotifyPropertyChanged
    {
        // Declare the database
        public readonly DoorControlDbContext dbContext;

        // Set the constructor
        public CreateBadgeViewModel(DoorControlDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            CreateBadgeCommand = new RelayCommand(CreateBadge);
        }

        // Declare the Create User Command
        public ICommand CreateBadgeCommand { get; }


        // Declare a private field for the new value
        int _badgeId;
        // Set its new value
        public int BadgeId
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
            // Check if required fields are empty
            if (BadgeId == 0 ) // You can adjust this condition based on your specific requirements
            {
                MessageBox.Show($"Please fill in a valid Badge number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Validation failed
            }

            // Check if a badge with the same BadgeId already exists in the database
            if (dbContext.Badges.Any(b => b.BadgeId == BadgeId))
            {
                MessageBox.Show($"Badge {BadgeId} already exists. Please enter a different Badge ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Validation failed
            }

            // Implement logic to create a Badge, perhaps by calling a method in your model
            Badge newBadge = new Badge
            {
                BadgeId = BadgeId,
            };

            // Add the badge to the context
            dbContext.Badges.Add(newBadge);

            // Save changes to the database
            dbContext.SaveChanges();



            // Add additional logic as needed, e.g., validation, interaction with your data context
            // Construct a message string with information about all Badges
            StringBuilder badgesInfo = new StringBuilder("Badges in the database:\n");

            foreach (var badge in dbContext.Badges)
            {
                badgesInfo.AppendLine($" BadgeID: {badge.BadgeId}");
            }

            // Display the message with badge information
            MessageBox.Show($"Badge {newBadge.BadgeId} created successfully!\n\n{badgesInfo.ToString()}");
        }


        // PropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
