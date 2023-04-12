using System;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace BookListLibrary.Services
{
	public class FirebaseConfigHelper
	{
        public static IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "PVXETWHDsuE7HsjKBi9nZlbbt2fw6BEzbZWdSG4c",
            BasePath = "https://booklist-90d5d-default-rtdb.firebaseio.com/"
        };
    }
}
