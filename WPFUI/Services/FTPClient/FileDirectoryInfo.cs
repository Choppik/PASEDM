namespace PASEDM.Services.FTPClient
{
    public class FileDirectoryInfo
    {
        private string _fileSize;
        private string _type;
        private string _name;
        private string _date;
        private string _address;

        public FileDirectoryInfo() { }

        public FileDirectoryInfo(string fileSize, string type, string name, string date, string address)
        {
            FileSize = fileSize;
            Type = type;
            Name = name;
            Date = date;
            Address = address;
        }
        public string FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

    }
}