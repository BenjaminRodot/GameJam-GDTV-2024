using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonShooterController>() != null)
        {
            Debug.Log("SOULÈVE MOI");
            other.GetComponent<ThirdPersonShooterController>().CanPickItem = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonShooterController>() != null)
        {
            Debug.Log("TM'A PAS SOULEVÉ");
            other.GetComponent<ThirdPersonShooterController>().CanPickItem = false;
        }
    }
}
