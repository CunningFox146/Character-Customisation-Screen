using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace DonutLab.Save
{
    public class FileSaveProvider : ISaveProvider
    {
        private string _filePath;

        public FileSaveProvider(string fileName)
        {
            _filePath = $"{Application.persistentDataPath}/{fileName}";
        }

        public GameData Load()
        {
            if (!File.Exists(_filePath)) return new GameData();

            try
            {
                return JsonConvert.DeserializeObject<GameData>(File.ReadAllText(_filePath));
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
            return new GameData();
        }

        public void Save(GameData gameData)
        {
            try
            {
                string json = JsonConvert.SerializeObject(gameData);
                File.WriteAllText(_filePath, json);

            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }
    }
}
