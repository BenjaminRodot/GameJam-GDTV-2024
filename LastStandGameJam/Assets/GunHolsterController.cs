using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolsterController : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] public Weapon activeWeapon;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
        activeWeapon = weapons[0];
        weapons[0].gameObject.SetActive(true);
    }
}
