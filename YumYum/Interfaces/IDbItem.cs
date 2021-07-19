using System;

namespace YumYum.Interfaces
{
    public interface IDbItem<T> //: ISaveable
    {
        T Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}