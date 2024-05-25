using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    public float normalSensitivity;
    public float aimSensitivity;

    private void Awake()
    {
        starterAssetsInputs= GetComponent<StarterAssetsInputs>();
        thirdPersonController= GetComponent<ThirdPersonController>();
        normalSensitivity = thirdPersonController.Sensitivity;
    }
    private void Update()
    {
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.Sensitivity = aimSensitivity;
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.Sensitivity = normalSensitivity;
        }
        
    }
}
