namespace ProjectZ.NState
{
    class Static : NUtil.Single<Static>
    {
        public Static() {
            _title = new Title();
        }

        public ref Title TITLE() {
            return ref _title;
        }

        private Title _title;
    }
}