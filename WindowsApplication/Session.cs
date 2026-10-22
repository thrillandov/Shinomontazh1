namespace ShinomontazhApp
{
    public static class Session
    {
        public static string CurrentUser { get; set; }
        public static string Role { get; set; }
        public static bool IsAdmin { get { return Role == "Admin"; } }

        public static void Clear()
        {
            CurrentUser = "";
            Role = "";
        }
    }
}