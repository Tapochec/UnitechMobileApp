using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.DependencyServices
{
    public interface IFileWorker
    {
        bool FileExists(string filename); // проверка существования файла
        void SaveFile(string filename, string text);   // сохранение текста в файл
        string LoadFile(string filename);  // загрузка текста из файла        
        void DeleteFile(string filename);  // удаление файла
    }
}
