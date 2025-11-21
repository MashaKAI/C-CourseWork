using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DAL.Exceptions;

namespace DAL.Storage
{
    public class JsonStorage
    {
        private readonly string _filePath;

        public JsonStorage(string filePath)
        {
            _filePath = filePath;

           
            string? directoryPath = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<T> Load<T>()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new StorageException($"Error loading file {_filePath}", ex);
            }
        }

        public void Save<T>(List<T> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new StorageException($"Error saving file {_filePath}", ex);
            }
        }
    }
}
