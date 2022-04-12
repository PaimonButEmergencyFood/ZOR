using System;
// Single pattern
// from https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff650316(v=pandp.10)

/**
namespace ProjectZ.NUtil {
    public sealed class Single
    {
        private static volatile Single instance;
        private static object syncRoot = new Object();

        private Single() {}

        public static Single Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                    if (instance == null) 
                        instance = new Single();
                    }
                }

                return instance;
            }
        }
    }
}
**/

namespace ProjectZ.NUtil {
        public abstract class Single<T> where T : Single<T>, new() {

        private static readonly T s_instance = new T();

        protected Single() {
            if (s_instance != null) {
                string s = string.Format(
                    "An instance of {0} already exists at {0}.instance. " +
                    "That's what \"Single\" means. You can't create another.",
                    typeof(T));
                throw new System.Exception(s);
            }
        }

        public static T instance { get { return s_instance; } }
    }
}