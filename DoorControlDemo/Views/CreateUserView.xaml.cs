using System.Windows;
using DoorControlDemo.Data;
using DoorControlDemo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DoorControlDemo.Views
{
    /// <summary>
    /// Interaction logic for CreateUserView.xaml
    /// </summary>
    public partial class CreateUserView : Window
    {
        // Create an instance of your view model and set it as the data context
        public CreateUserView()
        {
            InitializeComponent();
            // Configure the DbContextOptions. This can be an in-memory database or another provider.
            var options = new DbContextOptionsBuilder<DoorControlDbContext>()
                .UseInMemoryDatabase("usersDb") // Suitable name for the Db
                .Options;

            // Create the DbContext with the configured options
            var dbContext = new DoorControlDbContext(options);
            // Set the data context
            DataContext = new CreateUserViewModel(dbContext);
        }
    }
}
