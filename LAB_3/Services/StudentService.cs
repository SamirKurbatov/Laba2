using LAB_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAB_3.Services
{
    public class StudentService
    {
        // Создаем список для хранения данных из источника
        List<Student> studentList = new();


        // Метод GetStudent() служит для извлечения и сруктурирования данных
        // в соответсвии с существующей моделью данных
        public async Task<IEnumerable<Student>> GetStudent()
        {
            // Если список содержит какие-то элементы
            // то вернется последовательность с содержимым этого списка
            if (studentList?.Count > 0)
                return studentList;

            // В данном блоке кода осуществляется подключение, чтение
            // и дессериализация файла - источника данных
            using var stream = await FileSystem.OpenAppPackageFileAsync("student.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            studentList = JsonSerializer.Deserialize<List<Student>>(contents);
            return studentList;
        }


    }
}
