namespace ProjectZ {
    class Program {
        static void Main(string[] args) {
            User user = new User();
            Console.WriteLine("Hello World!");
            User.State.Command pCommand = user.GetState().GetCommand((ushort)NetCMDTypes.ZNO_CS_CONNECT);
            if (pCommand == null) {
                Console.WriteLine("pCommand is null");
            }
            else {
                Console.WriteLine("pCommand is not null");
                pCommand(ref user, null);
                user.printGID();
            }
        }
    }
}