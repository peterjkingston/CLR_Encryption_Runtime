using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Encryption_Runtime
{
    public class AdvancedEncryptionService: IDecryptor, IEncryptor, IKeyGenerator
    {
        private SymmetricAlgorithm _aes { get; set; }

        public AdvancedEncryptionService()
        {
            _aes = new AesManaged();
        }

        public byte[] Encrypt(string stringToEncrypt, byte[] key)
        {
            ICryptoTransform encryptor = _aes.CreateEncryptor(key, _aes.IV);
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWrite = new StreamWriter(cStream))
                    {
                        streamWrite.Write(stringToEncrypt);
                    }
                    return mStream.ToArray();
                }
            }                            
        }

        public string Decrypt(byte[] cipherText, byte[] key)
        {
            ICryptoTransform decryptor = _aes.CreateDecryptor(key, _aes.IV);
            using (MemoryStream mStream = new MemoryStream(cipherText))
            {
                using (CryptoStream cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sReader = new StreamReader(cStream))
                    {
                        return sReader.ReadToEnd();
                    }
                }
            }                                   
        }

        public byte[] GetKey()
        {
            _aes.GenerateKey();
            return _aes.Key;
        }
    }
}
