using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Encryption_Runtime
{
    public class RSAEncryptionProvider : IKeyGenerator, IEncryptor, IDecryptor
    {
        RSACryptoServiceProvider _rsa;

        public RSAEncryptionProvider()
        {
            _rsa = new RSACryptoServiceProvider();
        }

        public string Decrypt(byte[] encryptedData, byte[] key, byte[] vector)
        {
            UnicodeEncoding converter = new UnicodeEncoding();
            _rsa.FromXmlString(Encoding.UTF8.GetString(key));
            return converter.GetString( _rsa.Decrypt(encryptedData,false));
        }

        public byte[] Encrypt(string stringToEncrypt, byte[] key, byte[] vector)
        {
            UnicodeEncoding converter = new UnicodeEncoding();
            _rsa.FromXmlString(Encoding.UTF8.GetString(key));
            return _rsa.Encrypt(converter.GetBytes(stringToEncrypt), false);
        }

        public byte[] GetKey(bool isPrivate)
        {
            return Encoding.UTF8.GetBytes(_rsa.ToXmlString(isPrivate));
        }

        public byte[] GetVector()
        {
            return new byte[0];
        }
    }
}
