namespace TheGym
{
    public class DataManager
    {

        private static DataManager _instance;
        private string _data;

        private DataManager() { }

        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }

        //Get and set for data
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
