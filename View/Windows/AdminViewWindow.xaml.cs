using SportSectionWPF2.Data;
using SportSectionWPF2.Entities;
using SportSectionWPF2.View.Windows.WindowForAdminView;
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
using static System.Collections.Specialized.BitVector32;


namespace SportSectionWPF2.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminViewWindow.xaml
    /// </summary>
    public partial class AdminViewWindow : Window
    {
        private AppDbContext _context;
        public AdminViewWindow(AppDbContext context)
        {
            InitializeComponent();


            _context = context;

            DbLoad();
        }

        private void DbLoad()
        {
            _context.Sections.Load(); // Загружаем данные в память
            SectionsList.ItemsSource = _context.Sections.Local;
            SectionsList.DisplayMemberPath = "Name";



           
           
        }
        private void AddSectionButton_Click(object sender, RoutedEventArgs e)
        {
           AddSectionWindow addSectionWindow = new AddSectionWindow(_context);
           addSectionWindow.ShowDialog();

            
        }

        private void DeleteSEctionButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSection = SectionsList.SelectedItem as SectionEntity;

            if (selectedSection == null)
            {
                MessageBox.Show("Выберите секцию, которую хотите удалить!");
                return;
            }


            var SectionForDelte = _context.Sections.FirstOrDefault(s => s.Id == selectedSection.Id);

            if (SectionForDelte != null)
            {
                _context.Sections.Remove(SectionForDelte);
                _context.SaveChanges();
                MessageBox.Show("Секция успешно удалена!");
            }
        }

        private void SectionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSection = SectionsList.SelectedItem as SectionEntity;
            if (selectedSection == null)
                return;

            RightAppGrid.IsEnabled = true;
            RightAppGrid.Visibility = Visibility.Visible;

            WarrningTextBlock.Visibility = Visibility.Hidden;

            var section = _context.Sections
                .Include(s => s.Coach)
                .Include(s => s.Schedule)
                .Include(s => s.Members)
                .FirstOrDefault(s => s.Id == selectedSection.Id);

            if (section?.Coach != null)
            {
                _context.Entry(section.Coach).Reference(c => c.User).Load();
                SectionCoachLabel.Content = $"Тренер секции: {section.Coach.User.Name}";
            }
            else
            {
                SectionCoachLabel.Content = "Тренер не назначен";
            }

            if (section?.Schedule != null)
            {
                SchedualLabel.Content = $"Дата начала: {section.Schedule.StartTime:dd.MM.yyyy}, конец: {section.Schedule.EndTime:dd.MM.yyyy} с {section.Schedule.BeginTime} до {section.Schedule.EndingTime}";
            }
            else
            {
                SchedualLabel.Content = "Расписание отсутствует";
            }

            foreach (var member in section.Members)
            {
                _context.Entry(member).Reference(m => m.User).Load();
            }

            MembersDataGrid.ItemsSource = section.Members.ToList();
        }

        private void ChooseCoachButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSectionId = (SectionsList.SelectedItem as SectionEntity).Id;


            ChooseCoachForSection chooseCoachForSection = new ChooseCoachForSection(_context, selectedSectionId);
            chooseCoachForSection.ShowDialog();

            SectionsList_SelectionChanged(null, null);
        }

        

        private void AddScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSectionId = (SectionsList.SelectedItem as SectionEntity).Id;

            AddScheduleWindow addScheduleWindow = new AddScheduleWindow(_context, selectedSectionId);
            addScheduleWindow.ShowDialog();

            SectionsList_SelectionChanged(null, null);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SectionsList.SelectedItem == null)
            {
                MessageBox.Show("Выберите секцию!");
                return;
            }

            var selectedSection = SectionsList.SelectedItem as SectionEntity;

            if (selectedSection == null)
                return;

            var SectionForDelte = _context.Sections.FirstOrDefault(s => s.Id == selectedSection.Id);

            if (SectionForDelte.Schedule == null)
            {
                MessageBox.Show("Расписания нет в секции!");
                return;
            }

           var deletedSchedule =  _context.Schedules.FirstOrDefault(s => s.Id == SectionForDelte.Schedule.Id);

            _context.Schedules.Remove(deletedSchedule);
            _context.SaveChanges();

            MessageBox.Show("Расписание удалено!");
           

        }
        private void CoachDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SectionsList.SelectedItem == null)
            {
                MessageBox.Show("Выберите секцию!");
                return;
            }



            var selectedSection = SectionsList.SelectedItem as SectionEntity;

            if (selectedSection == null)
                return;

            var SectionForDelte = _context.Sections.FirstOrDefault(s => s.Id == selectedSection.Id);

            if (SectionForDelte.Coach == null)
            {
                MessageBox.Show("Тренера нет в секции!");
                return;
            }


            SectionForDelte.Coach = null;

            _context.SaveChanges();

            MessageBox.Show("Тренер удален из данной секции!");

            SectionCoachLabel.Content = "Тренер секции: ";
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSectionId = (SectionsList.SelectedItem as SectionEntity).Id;

            AddMemberWindow addMemberWindow = new AddMemberWindow(_context, selectedSectionId);
            addMemberWindow.ShowDialog();




            LoadMembersForSection();
        }
        private void LoadMembersForSection()
        {
            var selectedSection = SectionsList.SelectedItem as SectionEntity;

            if (selectedSection == null) 
                return;


            MembersDataGrid.ItemsSource = selectedSection.Members.ToList();


        }
        private void DeleteMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMember = MembersDataGrid.SelectedItem as MemberEntity;
            if (selectedMember == null)
            {
                MessageBox.Show("Выберите участника для удаления.");
                return;
            }

            
            var result = MessageBox.Show($"Удалить участника {selectedMember.User.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
                return;

            try
            {
                // Загружаем из контекста, чтобы Entity Framework отслеживал объект
                var memberToDelete = _context.Members.Find(selectedMember.Id);
                if (memberToDelete != null)
                {
                    _context.Members.Remove(memberToDelete);
                    _context.SaveChanges();

                    // Обновляем DataGrid — повторно загружаем участников текущей секции
                    var selectedSection = SectionsList.SelectedItem as SectionEntity;
                    if (selectedSection != null)
                    {
                        var sectionWithMembers = _context.Sections
                            .Include(s => s.Members.Select(m => m.User))
                            .FirstOrDefault(s => s.Id == selectedSection.Id);

                        MembersDataGrid.ItemsSource = sectionWithMembers?.Members.ToList() ?? null;
                    }
                    else
                    {
                        MembersDataGrid.ItemsSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message);
            }
        }
    }
}
