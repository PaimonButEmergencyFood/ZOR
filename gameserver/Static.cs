using ProjectZ.Logic;

namespace ProjectZ {
    public sealed class Static
    {
        private static readonly Static instance = new Static();

        private static Space _worldSpace;

        static Static()
        {
            _worldSpace = new Space();
        }

        private Static()
        {
        }

        public static Static Instance
        {
            get
            {
                return instance;
            }
        }

        public static Space GETWORLDSPACETREE() {
            return _worldSpace;
        }
    }
}