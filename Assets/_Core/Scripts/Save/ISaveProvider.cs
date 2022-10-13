namespace DonutLab.Save
{
    public interface ISaveProvider
    {
        public void Save(GameData gameData);
        public GameData Load();
    }
}
