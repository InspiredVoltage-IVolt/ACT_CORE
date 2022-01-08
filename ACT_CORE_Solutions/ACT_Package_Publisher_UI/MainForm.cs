namespace ACT_Package_Publisher_UI
{
    public partial class MainForm : Form
    {
        Dictionary<string, List<FileData>> _Files = new Dictionary<string, List<FileData>>();

        public MainForm()
        {
            InitializeComponent();
        }

        class publicationItem
        {
            public string FileName { get; set; }
            public string SourceKey { get; set; }
            public string PathToFile { get; set; }

            public override string ToString()
            {
                return FileName;
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "App\\ACT_Nuget_Publisher.exe", "-C \"" + AppDomain.CurrentDomain.BaseDirectory + "App\\Data\\");
            string? _LatestFile = null;

            try { _LatestFile = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "App\\Data\\", "*.json").OrderByDescending(x => x).First(); } catch { }

            if (!System.IO.File.Exists(_LatestFile)) { MessageBox.Show("No Data found"); return; }

            string value = System.IO.File.ReadAllText(_LatestFile);
            if (value == null || value == "") { MessageBox.Show("No Data found"); return; }

            object? _tmp = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<FileData>>>(value);

            if (_tmp == null) { MessageBox.Show("No Data found"); return; }

            _Files = (Dictionary<string, List<FileData>>)_tmp;

            foreach (string key in _Files.Keys)
            {
                Library_LlistBox.Items.Add(key);
            }
        }

        private void Library_LlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicationFile_listBox.Items.Clear();
            string? _K = Library_LlistBox.SelectedItem.ToString();
            if (_K == null) { return; }

            foreach (var pub in _Files[_K])
            {
                publicationItem _new = new publicationItem()
                {
                    FileName = pub.FileNameOnly,
                    PathToFile = pub.FullFilePath,
                    SourceKey = _K
                };

                PublicationFile_listBox.Items.Add(_new);
            }
        }

        private void PublishButton_Click(object sender, EventArgs e)
        {
            foreach (var tm in SelectedFiles_listBox.Items)
            {
                foreach (var itm in NuGetServers.Items)
                {
                    var id = (publicationItem)tm;

                    string _Call = "nuget push -s " + itm.ToString().Replace("###PACKAGE###", "\"" + id.PathToFile + "\" -k NIVOLT_BAGET");
                    System.Diagnostics.ProcessStartInfo _ProcessStartInfo = new System.Diagnostics.ProcessStartInfo();
                    _ProcessStartInfo.FileName = "dotnet";
                    _ProcessStartInfo.UseShellExecute = true;
                    _ProcessStartInfo.Arguments = _Call;
                    System.Diagnostics.Process.Start(_ProcessStartInfo);

                }
            }
        }

        private void PublicationFile_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PublicationFile_listBox.SelectedIndex == -1) { return; }

            if (SelectedFiles_listBox.Items.Contains((publicationItem)PublicationFile_listBox.SelectedItem)) { return; }
            SelectedFiles_listBox.Items.Add((publicationItem)PublicationFile_listBox.SelectedItem);

        }
    }
    class FileData
    {
        public bool WindowsFlag = false;
        public bool Is32Bit = false;
        public bool Is64Bit = false;
        public bool IsOther = false;
        public bool IsDebugVersion = false;
        public string FullFilePath = "";
        public string FileNameOnly = "";
        public DateTime LastModifiedDate = DateTime.MinValue;
    }
}