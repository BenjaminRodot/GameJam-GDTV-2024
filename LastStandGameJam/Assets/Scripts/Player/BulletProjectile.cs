using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    [SerializeField] private Transform vfxFlash;
    [SerializeField] private Transform vfxSparks;
    [SerializeField] private Transform vfxFire;
    [SerializeField] private Transform vfxSmoke;


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
            Destroy(gameObject);
        }
    }
}
