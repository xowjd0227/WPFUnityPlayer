using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUnityPlayer.Utils.Pattern
{
    [Serializable]
    public class Singleton<T> where T : class, new()
    {
        private static volatile T instance = null;
        private static readonly object syncRoot = new Object();

        protected Singleton() { }

        static public T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new T();
                    }
                }

                return instance;
            }
        }
    }
}
