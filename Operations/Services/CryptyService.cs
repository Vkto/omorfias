﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using API.Omorfias.Operations.Interfaces;
using System;

namespace API.Omorfias.Operations.Services
{
    public class CryptyService : ICryptyService
    {
        public string GenerateHashKey(string value)
        {
            byte[] salt = new byte[128 / 8];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: value,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;

        }
    }
}
