using ACT.Core.Interfaces.Security;

namespace ACT.Plugins.CodeGeneration.History
{
    public class ACT_History : ACT_Core, I_History
    {
        private SerializationType _SerializedAs = SerializationType.JSON;
        private string _Path = "";
        private bool _IsLoaded = false;

        public bool IsLoaded { get { return _IsLoaded; } }
        public string Path { get { return _Path; } }
        public SerializationType SerializedAs { get { return _SerializedAs; } }

        public List<I_HistoryItem> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddItem(string ProjectName, string FileName, string Password, string Date, string OriginalPath)
        {
            throw new NotImplementedException();
        }

        public void Create(I_UserInfo User, SerializationType Type, string StoragePath)
        {
            throw new NotImplementedException();
        }

        public List<I_HistoryItem> GetByDateRange(DateTime Start, DateTime End)
        {
            throw new NotImplementedException();
        }

        public void LoadItems(I_UserInfo User, string ProjectName, string Path = "")
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
