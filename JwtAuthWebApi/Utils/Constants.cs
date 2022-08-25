namespace JwtAuthWebApi.Utils;

public class Constants
{
    // TODO: Change these to environment variables
    public const string AUTH_KEY = "AuthKeyThatMustBeUniqueAndRandomUsingAlphanumericAndSpecialCharacters";
    public const string JWT_SECRET_KEY = "SecretKeyThatMustBeUniqueAndRandomUsingAlphanumericAndSpecialCharacters";

    public const string IDENTITY_DB_CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=jwt-auth-identity-webapi;Trusted_Connection=True;MultipleActiveResultSets=true";

    // TODO: Don't use this in production
    public const string DEFAULT_PASSWORD = "Pass@word1";

    public static class Roles
    {
        public const string ADMINISTRATOR = "Administrator";
        public const string USER = "User";
    }

    public static class Policies
    {
        public const string ADMINISTRATOR_ONLY = "AdministratorOnly";
        public const string USER_ONLY = "UserOnly";
    }
}
