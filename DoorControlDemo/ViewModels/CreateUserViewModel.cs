using DoorControlDemo.Data;
using DoorControlDemo.Models;
using GalaSoft.MvvmLight;
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

    public class CreateUserViewModel : INotifyPropertyChanged
    {
        // Declare the database
        public readonly DoorControlDbContext dbContext;

        // Set the constructor
        public CreateUserViewModel(DoorControlDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            CreateUserCommand = new RelayCommand(CreateUser);
        }

        // Declare the Create User Command
        public ICommand CreateUserCommand { get; }

        // Declare a private field for the new value
        string _userName;

        // Set its new value
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _userMail;
        public string UserMail
        {
            get => _userMail;
            set
            {
                _userMail = value;
                OnPropertyChanged(nameof(UserMail));
            }
        }

        private string _userPhoneNumber;

        public string UserPhoneNumber
        {
            get => _userPhoneNumber;
            set
            {
                _userPhoneNumber = value;
                OnPropertyChanged(nameof(UserPhoneNumber));
            }
        }

        // Create the method to be used as command
        // Use the data context to add the new user to the database
        public void CreateUser()
        {
            // Check if required fields are empty
            if (string.IsNullOrWhiteSpace(UserName) )
            {
                MessageBox.Show("Please fill in a name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Stop the user creation process
            }

            // Check if a device with the same properties already exists in the database
            if (dbContext.Users.Any(u => u.Name == UserName && u.Mail == UserMail && u.PhoneNumber == UserPhoneNumber))
            {
                MessageBox.Show($"User with the same properties already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Implement logic to create a user, perhaps by calling a method in your model
            User newUser = new User
            {
                Name = UserName,
                Mail = UserMail,
                PhoneNumber = UserPhoneNumber
            };

            // Add the user to the context
            dbContext.Users.Add(newUser);

            // Save changes to the database
            dbContext.SaveChanges();

            // Add additional logic as needed, e.g., validation, interaction with your data context

            MessageBox.Show($"User {newUser.Name} created successfully!"); // Display a message or handle success
        }


        // PropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
