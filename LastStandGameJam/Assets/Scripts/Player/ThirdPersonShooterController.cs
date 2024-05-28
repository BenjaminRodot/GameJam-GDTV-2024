using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderMask;
    [SerializeField] private Transform laserStartPoint;
    [SerializeField] private Transform aimTransform;

    [SerializeField] private Transform bulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;

    [SerializeField] private LineRenderer laser;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private Vector3 mouseWorldPosition;
    private Vector2 screenCenterPoint;

    [Header("Useful Bool")]
    [Tooltip("If you're on top of a pickable item, should turn true")]
    public bool CanPickItem = false;

    [Tooltip("If you are near an opeanable door")]
    public bool CanOpenDoor = false;

    [Header("Outside infos known by the player")]
    public PickableItem itemNearPlayer;
    public Door doorNearPlayer;

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
        mouseWorldPosition = Vector3.zero;
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        checkAim();
        checkShoot();
        checkInteract();
        checkGrenade();
    }

    private void checkAim()
    {

        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 999f, aimColliderMask))
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

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
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

    private void checkShoot()
    {
        if (starterAssetsInputs.shoot)
        {
            Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(bulletProjectile, spawnBulletPosition.position,Quaternion.LookRotation(aimDirection,Vector3.up));
            starterAssetsInputs.shoot = false;

            animator.SetTrigger("Shoot");
            animator.SetFloat("X", starterAssetsInputs.move.x);
            animator.SetFloat("Y", starterAssetsInputs.move.y);


            thirdPersonController.SetRotateOnMove(false);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = aimDirection;
        }
    }

    private void checkInteract()
    {
        if (starterAssetsInputs.interaction)
        {
            if (CanPickItem)
            {
                Debug.Log("Interaction ta maman");
                animator.SetTrigger("Pickup");
                Destroy(itemNearPlayer.gameObject);
                CanPickItem = false;
                itemNearPlayer = null;
            }
            else if (doorNearPlayer)
            {
                animator.SetTrigger("Use");
                if (doorNearPlayer.IsClosed)
                {
                    Debug.Log("OPEN THE DOOR");
                    doorNearPlayer.OpenDoor();
                    animator.SetTrigger("StopUse");
                }
                else
                {
                    Debug.Log("CLOSE THE DOOR");
                    doorNearPlayer.CloseDoor();
                    animator.SetTrigger("StopUse");
                }
                
            }
            starterAssetsInputs.interaction = false;
        }

        
    }

    private void checkGrenade()
    {
        if (starterAssetsInputs.grenade)
        {
            //Do grenade shit
            animator.SetTrigger("Grenade");
            starterAssetsInputs.grenade = false;

            animator.SetFloat("X", starterAssetsInputs.move.x);
            animator.SetFloat("Y", starterAssetsInputs.move.y);

            thirdPersonController.SetRotateOnMove(false);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = aimDirection;
        }
    }

    public void EndPickup()
    {
        Debug.Log("Fin de l'animation de pickup");
    }
}
