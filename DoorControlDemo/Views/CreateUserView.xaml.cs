using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
                .UseInMemoryDatabase("usersDb") // Replace with a meaningful name
                .Options;

            // Create the DbContext with the configured options
            var dbContext = new DoorControlDbContext(options);
            // Set the data context
            DataContext = new CreateUserViewModel(dbContext);
        }
    }
}
