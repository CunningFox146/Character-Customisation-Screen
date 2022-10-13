using UnityEngine;

namespace DonutLab.Save
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private bool _isSaveToFile;
        [SerializeField] private string _saveFileName;
        private ISaveProvider _saveProvider;

        private GameData _gameData;
        public GameData GameData => _gameData;

        private void Awake()
        {
            InitProvider();
            _gameData = _saveProvider.Load();
        }

        public void Save() => _saveProvider.Save(_gameData);

        private void InitProvider()
        {
            if (_isSaveToFile)
            {
                _saveProvider = new FileSaveProvider(_saveFileName);
            }
            else
            {
                _saveProvider = new PlayerPrefsSaveProvider();
            }
        }

    }
}
