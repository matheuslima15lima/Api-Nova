﻿namespace Webapi.HealthClinic.tarde.Utils
{
    public class Criptografia
    {
        public static string GerarGash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }


        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
