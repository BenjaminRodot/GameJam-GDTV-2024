using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ItemData stats;

    public float rateOfFire, reloadTime, range, spread;

    public int damage, magazineSize, bulletPerShot, pelletsPerShot;

    private void Awake()
    {
        damage = stats.BaseDamage;
        magazineSize= stats.BaseMagazineSize;
        bulletPerShot = stats.BaseBulletsPerShot;
        pelletsPerShot = stats.BasePelletsPerShot;
        rateOfFire = stats.RateOfFire;
        reloadTime = stats.ReloadSpeed;
        range = stats.BaseRange;
        spread = stats.Spread;
    }
}
