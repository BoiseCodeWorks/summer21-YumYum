using System.Collections.Generic;
using YumYum.Models;

namespace YumYum.Interfaces
{
    public interface ISaveable
    {
        // IDbItem Save();
        void Update();
        void Delete();
    }
}