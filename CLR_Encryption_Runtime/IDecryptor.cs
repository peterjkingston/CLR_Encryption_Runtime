using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Encryption_Runtime
{
    public interface IDecryptor
    {
        string Decrypt(byte[] encryptedData, byte[] key, byte[] vector);
    }
}
