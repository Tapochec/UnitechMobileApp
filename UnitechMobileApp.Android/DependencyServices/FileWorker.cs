using System;
using System.IO;
using UnitechMobileApp.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(UnitechMobileApp.Droid.DependencyServices.FileWorker))]
namespace UnitechMobileApp.Droid.DependencyServices
{
    class FileWorker : IFileWorker
    {
        public void DeleteFile(string filename)
        {
            File.Delete(GetFilePath(filename));
        }

        public bool FileExists(string filename)
        {
            // получаем путь к файлу
            string filepath = GetFilePath(filename);
            // существует ли файл
            bool exists = File.Exists(filepath);
            return exists;
        }

        public string LoadFile(string filename)
        {
            string filepath = GetFilePath(filename);
            using (StreamReader reader = File.OpenText(filepath))
            {
                return reader.ReadToEnd();
            }
        }

        public void SaveFile(string filename, string text)
        {
            string filepath = GetFilePath(filename);
            using (StreamWriter writer = File.CreateText(filepath))
            {
                writer.Write(text);
            }
        }

        // вспомогательный метод для построения пути к файлу
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }

        // получаем путь к папке MyDocuments
        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}