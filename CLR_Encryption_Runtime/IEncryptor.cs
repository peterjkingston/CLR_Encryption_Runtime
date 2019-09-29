using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Encryption_Runtime
{
    public interface IEncryptor
    {
        byte[] Encrypt(string stringToEncrypt, byte[] key, byte[] vector);
    }
}
