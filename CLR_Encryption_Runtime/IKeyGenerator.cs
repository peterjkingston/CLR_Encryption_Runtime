using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Encryption_Runtime
{
    public interface IKeyGenerator
    {
        byte[] GetKey(bool isPrivate);
        byte[] GetVector();
    }
}
