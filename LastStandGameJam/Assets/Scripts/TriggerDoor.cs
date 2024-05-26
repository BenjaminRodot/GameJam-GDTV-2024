using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] Door relatedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ThirdPersonShooterController>() != null)
        {
            other.GetComponent<ThirdPersonShooterController>().CanOpenDoor = true;
            other.GetComponent<ThirdPersonShooterController>().doorNearPlayer = relatedDoor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonShooterController>() != null)
        {
            other.GetComponent<ThirdPersonShooterController>().CanOpenDoor = false;
            other.GetComponent<ThirdPersonShooterController>().doorNearPlayer = null;
        }
    }


}
