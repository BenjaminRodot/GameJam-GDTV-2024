using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : BulletTarget
{
    private NavigationScript _navigationScript;

    private void Start()
    {
        _navigationScript = gameObject.GetComponent<NavigationScript>();
    }

    public void Damaged(int damage)
    {
        _navigationScript.Damaged(damage);
    }
}
