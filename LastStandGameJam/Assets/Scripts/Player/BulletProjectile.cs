using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    [SerializeField] private Transform vfxFlash;
    [SerializeField] private Transform vfxSparks;
    [SerializeField] private Transform vfxFire;
    [SerializeField] private Transform vfxSmoke;

    [SerializeField] private int _bulletDamage = 3;


    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 10f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(vfxSparks, transform.position, Quaternion.identity);
            Instantiate(vfxFlash, transform.position, Quaternion.identity);
            Instantiate(vfxFire, transform.position, Quaternion.identity);
            Instantiate(vfxSmoke, transform.position, Quaternion.identity);
            if (other.GetComponent<BulletTarget>().GetType().Equals("Enemy"))
            {
                other.GetComponent<NavigationScript>().Damaged(_bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
