using System;
using DotNetEnv;

namespace ApiLibraryManagement
{
    public static class EnvConfig
    {
        static EnvConfig()
        {
            Env.Load();
        }

        public static string DbServer => Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
        public static string DbName => Environment.GetEnvironmentVariable("DB_NAME") ?? "ApiLibraryManagement";
        public static string DbUser => Environment.GetEnvironmentVariable("DB_USER") ?? "SA";
        public static string DbPassword => Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "MyStrongPass123!";
        public static string JwtSecret => Environment.GetEnvironmentVariable("JWT_SECRET") ?? "MiSecretoPorDefecto123!";

        public static string GetConnectionString()
        {
            return $"Server={DbServer};" +
                   $"Database={DbName};" +
                   $"User ID={DbUser};" +
                   $"Password={DbPassword};" +
                   "TrustServerCertificate=true;MultipleActiveResultSets=true";
        }
    }
}