namespace Application
{
    public enum ErrorCode
    {
        // Book 1 to 99
        BOOK_INVALID_NAME = 1,
        BOOK_INVALID_BIO = 2,
        BOOK_INVALID_AUTHOR = 3,
        BOOK_INVALID_PUBLISING_COMPANY = 4,
        BOOK_INVALID_PAGE = 5,
        BOOK_INVALID_EDITION = 6,
        BOOK_COLD_NOT_SAVE = 7,
        BOOK_COLD_NOT_UPDATE = 8,
        BOOK_NOT_FOUND = 9,

        // User 100 to 199
        USER_INVALID_NAME = 100,
        USER_INVALID_LASTNAME = 101,
        USER_INVALID_EMAIL = 102,
        USER_INVALID_PASSWORDHASH = 103,
        USER_COLD_NOT_SAVE = 104,
        USER_COLD_NOT_UPDATE = 105,
        USER_NOT_FOUND = 106,

        // Role 200 to 299
        ROLE_INVALID_NAME = 200,
        ROLE_COLD_NOT_SAVE = 201,
        ROLE_COLD_NOT_UPDATE = 202,
        ROLE_NOT_FOUND = 203,
    }

    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public ErrorCode ErrorCode { get; set; }
    }
}
