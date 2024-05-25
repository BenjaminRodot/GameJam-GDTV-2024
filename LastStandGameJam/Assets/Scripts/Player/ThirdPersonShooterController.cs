using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderMask;
    [SerializeField] private Transform laserStartPoint;
    [SerializeField] private Transform aimTransform;

    [SerializeField] private LineRenderer laser;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake()
    {
        starterAssetsInputs= GetComponent<StarterAssetsInputs>();
        thirdPersonController= GetComponent<ThirdPersonController>();
        normalSensitivity = thirdPersonController.Sensitivity;
        animator= GetComponent<Animator>();
        laser.positionCount= 2;
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 999f, aimColliderMask))
        {
            aimTransform.position = hitInfo.point;
            mouseWorldPosition = hitInfo.point;
        }
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            laser.gameObject.SetActive(true);
            laser.SetPosition(0, laserStartPoint.transform.position);
            laser.SetPosition(1, aimTransform.position);
            thirdPersonController.Sensitivity = aimSensitivity;
            thirdPersonController.SetRotateOnMove(false);
            animator.SetBool("Aiming", true);
            animator.SetFloat("X", starterAssetsInputs.move.x);
            animator.SetFloat("Y", starterAssetsInputs.move.y);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection ,Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            laser.gameObject.SetActive(false);
            animator.SetBool("Aiming", false);
            thirdPersonController.Sensitivity = normalSensitivity;
        }
    }
}
