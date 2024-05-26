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
            Debug.Log("SOUL�VE MOI");
            other.GetComponent<ThirdPersonShooterController>().CanPickItem = true;
            other.GetComponent<ThirdPersonShooterController>().itemNearPlayer = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ThirdPersonShooterController>() != null)
        {
            Debug.Log("TM'A PAS SOULEV�");
            other.GetComponent<ThirdPersonShooterController>().CanPickItem = false;
            other.GetComponent<ThirdPersonShooterController>().itemNearPlayer = null;
        }
    }
}
