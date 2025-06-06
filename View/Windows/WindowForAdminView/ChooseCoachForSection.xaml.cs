using SportSectionWPF2.Data;
using SportSectionWPF2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace SportSectionWPF2.View.Windows.WindowForAdminView
{
    /// <summary>
    /// Логика взаимодействия для ChooseCoachForSection.xaml
    /// </summary>
    public partial class ChooseCoachForSection : Window
    {
        private AppDbContext _context;
        private int _sectionId;
        public ChooseCoachForSection(AppDbContext context, int sectionId)
        {
            InitializeComponent();

            _sectionId = sectionId;
            _context = context;

            DbLoad();


           
            
        }

        private void AddCoachButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Введите имя тренера!");
                return;
            }
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Введите пароль для добавления!");
                return;
            }
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Введите E-mail для добавления тренера!");
                return;
            }


            UserEntity user = new UserEntity()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Text,
                Role = "Тренер"
            };


            _context.Users.Add(user);
            _context.SaveChanges();

            CoachEntity coachEntity = new CoachEntity()
            {
                User = user,
            };

            _context.Coachs.Add(coachEntity);
            _context.SaveChanges();

            MessageBox.Show("Тренер успешно добавлен!");

            DbLoad();
        }
        private void DbLoad()
        {
            if (_context.Coachs == null)
                return;

            _context.Coachs.Load();
            CoachesListBox.ItemsSource = _context.Coachs.Local;

            var coaches = _context.Coachs.Include(c => c.User).ToList();
            CoachesListBox.ItemsSource = coaches;


            CoachesListBox.DisplayMemberPath = "DisplayName";
        }
        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChooseCoachButton_Click(object sender, RoutedEventArgs e)
        {
            var section = _context.Sections.FirstOrDefault(s => s.Id == _sectionId);

            var selectedCoach = CoachesListBox.SelectedItem as CoachEntity;

            if (selectedCoach == null)
            {
                MessageBox.Show("Выберите тренера!");
                return;
            }
            section.Coach = selectedCoach;

            _context.SaveChanges();
            MessageBox.Show("Тренер добавлен к секции!");
            this.Close();
        }
    }
}
