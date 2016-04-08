namespace App.DTO.Enums
{
    public static class BaseEnums
    {
        // Last category - 101
        // Last reference - 1004

        public static class Reference
        {
            public enum Category
            {
                Settings = 100,
                Gender = 101
            }

            public enum Settings
            {
                AppHost = 1003,
                ResizerHost = 1004
            }

            public enum Gender
            {
                Male = 1000,
                Female = 1001,
                Unknown = 1002
            }
        }
    }
}
