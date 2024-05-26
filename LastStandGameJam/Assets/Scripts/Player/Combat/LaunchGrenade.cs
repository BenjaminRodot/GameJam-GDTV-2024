using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{
    [SerializeField] private GameObject _grenadePrefab;

    [SerializeField] private float angle = 45;
    [SerializeField] private float speed = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Mathf.Deg2Rad * angle ) * speed, transform.position.z + Mathf.Cos(Mathf.Deg2Rad * angle) * speed)) ;
    }


}
