using UnityEngine;

public interface IProduct<T> where T : ScriptableObject
{
    T BullletData { get; }
}
