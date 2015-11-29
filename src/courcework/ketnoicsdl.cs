using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
namespace courcework
{
    class ketnoicsdl
    {
     public  static IObjectContainer db;
        public static IObjectContainer Opendb(string dl)
        {
             db = Db4oEmbedded.OpenFile(dl);
            return db;
        }
    }

}
