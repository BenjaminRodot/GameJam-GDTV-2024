using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Canvas : MonoBehaviour
{
    [SerializeField] private GameObject _currentPanel;
    [SerializeField] private GameObject _newpanel;
    
    public void ChangeCanvas()
    {
        _currentPanel.SetActive(false);
        _newpanel.SetActive(true);
    }
}
