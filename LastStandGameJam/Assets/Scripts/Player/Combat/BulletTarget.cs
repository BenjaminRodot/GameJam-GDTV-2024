using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    [SerializeField] private string type;

    public string GetType()
    {
        return type;
    }
}
