using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool: MonoBehaviour
{
    public List<GameObject> inUse = new List<GameObject>();
    public List<GameObject> available = new List<GameObject>();
    [SerializeField] private GameObject prefab;
    public GameObject Use()
    {
        GameObject t;
        if (available.Count > 0)
        {
            t = available[0];
            t.SetActive(true);
            available.RemoveAt(0);
            inUse.Add(t);
            return t;
        }
        else
        {
            t = Instantiate(prefab, transform.position, Quaternion.identity);
            inUse.Add(t);
            return t;
        }
    
    }
    
    public void Recycle(GameObject t)
    {
        if (!inUse.Contains(t)) return;
        inUse.Remove(t);
        available.Add(t);
        t.SetActive(false);
    }

}
