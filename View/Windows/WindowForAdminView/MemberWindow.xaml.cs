using SportSectionWPF2.Data;
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
using SportSectionWPF2.Entities;
using System.Runtime.Remoting.Contexts;


namespace SportSectionWPF2.View.Windows.WindowForAdminView
{
    /// <summary>
    /// Логика взаимодействия для MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        private int _memberId;
        private AppDbContext _context;
        public MemberWindow(AppDbContext context, int memberId)
        {
            InitializeComponent();

            _context = context;
            _memberId = memberId;


            DbLoad();
        }

        private void DbLoad()
        {
            // Получаем все секции, где есть участник с заданным _memberId
            var sections = _context.Sections
                .Include(s => s.Members)
                .Where(s => s.Members.Any(m => m.Id == _memberId))
                .ToList();
            SectionsList.ItemsSource = sections;




            var archi = _context.Achievements.Where(s => s.Member.Id == _memberId);

            if (archi != null)
            {
               
                AchivmentDataGrid.ItemsSource = archi.ToList();
            }


        }

        private void SectionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSection = SectionsList.SelectedItem as SectionEntity;
            UpdateSectionInfo(selectedSection, CoachSection, SchedualLabel, _context);

        }
        public void UpdateSectionInfo(SectionEntity selectedSection, Label coachLabel, Label scheduleLabel, AppDbContext context)
        {
            if (selectedSection == null)
            {
                coachLabel.Content = "";
                scheduleLabel.Content = "";
                return;
            }

            var section = context.Sections
                .Include(s => s.Coach)
                .Include(s => s.Schedule)
                .FirstOrDefault(s => s.Id == selectedSection.Id);

            if (section == null)
            {
                coachLabel.Content = "Тренер: не назначен";
                scheduleLabel.Content = "Расписание: не задано";
                return;
            }

            if (section.Coach != null)
            {
                var user = context.Users.FirstOrDefault(u => u.Id == section.Coach.UserId);
                coachLabel.Content = $"Тренер секции: {user.Name}";
            }
            else
            {
                coachLabel.Content = "Тренер: не назначен";
            }

            if (section.Schedule != null)
            {
                scheduleLabel.Content = $"Расписание: {section.Schedule.StartTime:HH:mm} - {section.Schedule.EndTime:HH:mm} c {section.Schedule.BeginTime} до {section.Schedule.EndingTime}";
            }
            else
            {
                scheduleLabel.Content = "Расписание: не задано";
            }
        }
        private void AchivmentButton_Click(object sender, RoutedEventArgs e)
        {
            WIndowForMember wIndowForMember = new WIndowForMember(_context, _memberId);
            wIndowForMember.ShowDialog();


            DbLoad();

        }
    }
}
