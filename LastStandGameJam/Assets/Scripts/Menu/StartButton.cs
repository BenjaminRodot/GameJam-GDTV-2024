using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _menuPanel;

    [SerializeField] private GameObject _playerWithScript;
    [SerializeField] private GameObject _playerWithoutScript;

    public void StartIntro()
    {
        _menuPanel.SetActive(false);
        _animator.SetTrigger("StartIntroCam");
        _playerWithScript.SetActive(true);
        _playerWithoutScript.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
