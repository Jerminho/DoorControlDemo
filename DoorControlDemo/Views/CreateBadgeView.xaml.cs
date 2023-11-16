using DoorControlDemo.Data;
using DoorControlDemo.ViewModels;
using Microsoft.EntityFrameworkCore;
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

namespace DoorControlDemo.Views
{
    /// <summary>
    /// Interaction logic for CreateBadgeView.xaml
    /// </summary>
    public partial class CreateBadgeView : Window
    {
        public CreateBadgeView()
        {
            InitializeComponent();
            // Configure the DbContextOptions. This can be an in-memory database or another provider.
            var options = new DbContextOptionsBuilder<DoorControlDbContext>()
                .UseInMemoryDatabase("BadgesDb") // Suitable name for the Db
                .Options;

            // Create the DbContext with the configured options
            var dbContext = new DoorControlDbContext(options);
            // Set the data context
            DataContext = new CreateBadgeViewModel(dbContext);
        }
    }
}
