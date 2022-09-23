using LAB_3.Models;
using LAB_3.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LAB_3.ViewModels
{
    public class StudentViewModel : BindableObject
    {
        // Переменная для хранения состояния
        // выбранного элемента коллекции
        private Student _selectedItem;
        // Объект с логикой по извлечению данных
        // из источника
        StudentService studentService = new();

        // Коллекция извлекаемых объектов
        public ObservableCollection<Student> Students { get; } = new();

        // Конструктор с вызовом метода
        // получения данных
        public StudentViewModel()
        {
            GetStudentAsync();
        }

        // Публичное свойство для представления
        // описания выбранного элемента из коллекции
        public string Desc { get; set; }
        public string Title { get; set; }

        public bool CurrentColor { get; set; }

        // Свойство для представления и изменения
        // состояния выбранного объекта
        public Student SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Desc = value?.Description;
                // Метод отвечает за обновление данных
                // в реальном времени
                OnPropertyChanged(nameof(Desc));
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CurrentColor));
            }
        }

        // Команда для добавления нового элемента
        // в коллекцию
        public ICommand AddItemCommand => new Command(() => AddNewItem());
        public ICommand RemoveItemCommand => new Command(() => RemoveItem());

        private void RemoveItem()
        {
            Students.Remove(_selectedItem);
        }

        // Метод для создания нового элемента
        private void AddNewItem()
        {
            Students.Add(new Student
            {
                Id = Students.Count + 1,
                Name = "Title " + Students.Count,
                Description = "Description",
                TypeOfStudents = "country"
            });
        }

        // Метод получения коллекции объектов
        async Task GetStudentAsync()
        {
            try
            {
                var students = await studentService.GetStudent();

                if (Students.Count != 0)
                    Students.Clear();

                foreach (var student in students)
                {
                    Students.Add(student);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!",
                $"Что-то пошло не так: {ex.Message}", "OK");
            }
        }

    }
}