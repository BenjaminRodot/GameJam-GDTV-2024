using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXTest : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    [SerializeField] private TakeDamageVFX _takeDamageVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(_bomb);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2)) 
        {
            StartCoroutine(_takeDamageVFX.TakeDamageEffect(0.2f));
        }
    }
}
