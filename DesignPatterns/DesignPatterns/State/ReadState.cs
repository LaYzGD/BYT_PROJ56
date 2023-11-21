
using System.IO;

namespace DesignPatterns.State
{
    public class ReadState : State
    {
        private string _path;

        public ReadState(Client client, StateHandler stateHandler, string path) : base(client, stateHandler)
        {
            _path = path;
        }

        private void SetPath(string path) => _path = path;

        private string Read()
        {
            try
            {
                if (File.Exists(_path))
                {
                    using (StreamReader sr = new StreamReader(_path))
                    {
                        string fileContents = sr.ReadToEnd();

                        return fileContents;
                    }
                }

                return "Can't find a file";
            }
            catch(Exception ex) 
            {
                return $"Error: {ex.StackTrace}";
            }
        }

        public override void Handle()
        {
            base.Handle();
            Console.WriteLine("What do you want me to read?");
            string file = Console.ReadLine();
            if (!string.IsNullOrEmpty(file))
            {
                SetPath(file);
                Console.WriteLine(Read());
                stateHandler.SetState(client.InitialState);
            }
        }
    }
}
