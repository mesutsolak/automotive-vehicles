namespace AutomotiveBrands.Lib.Security.Utilities
{
    /// <summary>
    /// Security helper
    /// </summary>
    public static class SecurityExtensions
    {
        /// <summary>
        /// Create password hash
        /// </summary>
        /// <param name="password">password</param>
        /// <remarks>warning: reverseless</remarks>
        /// <returns>hashed password</returns>
        /// <exception cref="ArgumentNullException">if method parameters are whitespace or null</exception>
        public static string CreatePasswordHash(this string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password), ExceptionMessage.InputRequired);

            return Crypto.HashPassword(password);
        }

        /// <summary>
        /// Verify password hash
        /// </summary>
        /// <param name="hashedPassword">hashed password</param>
        /// <param name="password">password</param>
        /// <remarks>warning: irreversible, just checking for correctness.</remarks>
        /// <returns>type of boolean</returns>
        /// <exception cref="ArgumentNullException">if method parameters are whitespace or null</exception>
        public static bool VerifyPasswordHash(this string hashedPassword, string password)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword))
                throw new ArgumentNullException(nameof(hashedPassword), ExceptionMessage.HashedValueRequired);

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password), ExceptionMessage.InputRequired);

            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }

        /// <summary>
        /// Reversible encryption
        /// </summary>
        /// <param name="text">text to be encrypted</param>
        /// <remarks>information: reversive</remarks>
        /// <returns>encrypted text</returns>
        /// <exception cref="ArgumentNullException">if method parameters are whitespace or null</exception>
        public static string Encrypt(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text), ExceptionMessage.TextToBeEncryptedRequired);

            byte[] key = Encoding.UTF8.GetBytes("E546C8DF278CD5931069B522E695D4F2");

            using Aes aes = Aes.Create();
            using ICryptoTransform cryptoTransform = aes.CreateEncryptor(key, aes.IV);
            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, cryptoTransform, CryptoStreamMode.Write);
            using (StreamWriter streamWriter = new(cryptoStream))
            {
                streamWriter.Write(text);
            }

            byte[] iv = aes.IV;
            byte[] decryptedContent = memoryStream.ToArray();
            byte[] result = new byte[iv.Length + decryptedContent.Length];

            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// Decrypts the encrypted value
        /// </summary>
        /// <remarks>decrypts the value based on the key value</remarks>
        /// <param name="cipherText">cipher text</param>
        /// <returns>decrypted value by key value</returns>
        /// <exception cref="ArgumentNullException">if method parameters are whitespace or null</exception> 
        public static string Decrypt(this string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
                throw new ArgumentNullException(nameof(cipherText), ExceptionMessage.CipherTextRequired);

            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);

            byte[] key = Encoding.UTF8.GetBytes("E546C8DF278CD5931069B522E695D4F2");

            using Aes aes = Aes.Create();
            using ICryptoTransform cryptoTransform = aes.CreateDecryptor(key, iv);

            string text;
            using (MemoryStream memoryStream = new(cipher))
            {
                using CryptoStream cryptoStream = new(memoryStream, cryptoTransform, CryptoStreamMode.Read);
                using StreamReader streamWriter = new(cryptoStream);
                text = streamWriter.ReadToEnd();
            }

            return text;
        }

        public static string ToSHA512(this string text)
        {
            using var hashAlgorithm = SHA512.Create();
            var byteValue = Encoding.UTF8.GetBytes(text);
            var byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
}
