using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Encryption_Runtime
{
    interface IDecryptor
    {
        string Decrypt(byte[] encryptedData, byte[] key);
    }
}
