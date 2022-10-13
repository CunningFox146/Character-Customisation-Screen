using UnityEngine;

namespace DonutLab.Save
{
    public class PlayerPrefsSaveProvider : ISaveProvider
    {
        private static readonly string CharacterSkinKey = "Customisation.CharacterSkin";
        private static readonly string StandSkinKey = "Customisation.StandSkin";

        public GameData Load()
        {
            return new GameData()
            {
                CharacterSkin = PlayerPrefs.GetString(CharacterSkinKey),
                StandSkin = PlayerPrefs.GetString(StandSkinKey),
            };
        }

        public void Save(GameData gameData)
        {
            PlayerPrefs.SetString(CharacterSkinKey, gameData.CharacterSkin);
            PlayerPrefs.SetString(StandSkinKey, gameData.StandSkin);
            PlayerPrefs.Save();
        }
    }
}
