using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using System.IO;
using System.Windows.Forms;

namespace OODBDemo.DBAccess
{
    public class DBConnect
    {
        public IObjectContainer db { get; set; }
        public readonly string _default_db_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "App_Data", "oodb.db4o");

        public IObjectContainer Open(string dl)
        {
            //if (!File.Exists(dl))
            //{
            //    MessageBox.Show("Database file not exist!");
            //}

            db = Db4oEmbedded.OpenFile(dl);
            return db;
        }

        public IObjectContainer Open()
        {
            this.Open(_default_db_path);
            return db;
        }

        public DBConnect()
        {
            db = Db4oEmbedded.OpenFile(dl);
        }


    }
}
