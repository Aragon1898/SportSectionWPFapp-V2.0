using SportSectionWPF2.Data;
using SportSectionWPF2.Entities;
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
using System.Data.Entity;

namespace SportSectionWPF2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для WIndowForMember.xaml
    /// </summary>
    public partial class WIndowForMember : Window
    {
        private AppDbContext _context;
        private int _memberId;
        public WIndowForMember(AppDbContext context, int memberId)
        {
            InitializeComponent();
            _memberId = memberId;
            _context = context;
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем участника из БД
            var member = _context.Members
                .Include(m => m.Achievements)
                .FirstOrDefault(m => m.Id == _memberId);

            if (member != null)
            {
                // Создаем новое достижение
                var newAchievement = new AchievementEntity
                {
                    CompetitionName = NameCompetion.Text,
                    Points = PointsTextBox.Text,
                    Awards = AwardsTextBox.Text,
                    Member = member,
                    MemberId = _memberId
                };


                _context.Achievements.Add(newAchievement);
                _context.SaveChanges();

                // Добавляем достижение участнику
                member.Achievements.Add(newAchievement);

                // Сохраняем изменения в базе данных
                _context.SaveChanges();

                MessageBox.Show("Достижение добавлено!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Участник не найден.");
            }

           
        }
    }
}
