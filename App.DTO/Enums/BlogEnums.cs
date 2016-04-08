namespace App.DTO.Enums
{
    public static class BlogEnums
    {
        // Last category - 401
        // Last reference - 4003

        public static class Reference
        {
            public enum Category
            {
                Settings = 400,
                BlogPostStatus = 401
            }

            public enum Settings
            {
                IsCommentsAllowed = 4001
            }

            public enum BlogPostStatus
            {
                Draft = 4002,
                Published = 4003
            }
        }
    }
}
