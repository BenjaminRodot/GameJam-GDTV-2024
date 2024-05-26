using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    private Rigidbody _grenadeRigidbody;
    [SerializeField] private Transform vfxExplosion;

    [SerializeField] private int _grenadeDamage = 20;
    [SerializeField] private float _grenadeRange = 1f;



    private void Awake()
    {
        _grenadeRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(vfxExplosion, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, _grenadeRange);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<BulletTarget>() && collider.GetComponent<BulletTarget>().GetType().Equals("Enemy"))
            {
                collider.GetComponent<NavigationScript>().Damaged(_grenadeDamage);
            }
        }
        Destroy(gameObject);
    }

    public void Launch(float angle, float speed)
    {
        Vector3 launchVector = new Vector3(0, Mathf.Sin(2f * Mathf.PI / 360 * angle) * speed, Mathf.Cos(2f * Mathf.PI / 360 * angle) * speed);
        _grenadeRigidbody.velocity = launchVector;
    }

}
