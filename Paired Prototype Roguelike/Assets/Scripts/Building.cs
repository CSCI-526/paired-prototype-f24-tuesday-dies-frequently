using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] public bool placed = false;
    public virtual void OnPlace()
    {
        placed = true;
        foreach(Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }
    }
}
