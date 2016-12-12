namespace BDAC
{
    public class Settings
    {
        private bool tray = false;
        private bool autoclose = false;
        private bool shutdown = false;

        public bool Tray
        {
            get { return tray; }
            set { tray = value; }
        }

        public bool AutoClose
        {
            get { return autoclose; }
            set { autoclose = value; }
        }

        public bool Shutdown
        {
            get { return shutdown; }
            set { shutdown = value; }
        }
    }
}
