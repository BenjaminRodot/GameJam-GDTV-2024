using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject _doorGameObject;
    [SerializeField]
    private int _openCloseSpeed;
    [SerializeField]
    private GameObject _closedPosition;
    [SerializeField]
    private GameObject _openedPosition;

    private bool _isClosed;
    private bool _isOpening;
    private bool _isClosing;


    public bool IsClosed => _isClosed;
    public bool IsOpening => _isOpening;
    public bool IsClosing => _isClosing;

    // Start is called before the first frame update
    void Awake()
    {
        _isClosed = true;
        _isOpening = false;
        _isClosing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isOpening && !_isClosing)
        {
            return;
        }

        if(_isOpening || _isClosing)
        {
            Vector3 targetPosition;
            if (_isOpening)
            {
                targetPosition = _openedPosition.transform.position;
            }
            else
            {
                targetPosition = _closedPosition.transform.position;
            }
            float step = _openCloseSpeed * Time.deltaTime;
            _doorGameObject.transform.position = Vector3.MoveTowards(_doorGameObject.transform.position, targetPosition, step);

        }

        if (_doorGameObject.transform.position == _openedPosition.transform.position)
        {
            _isOpening = false;
            _isClosed = false;
        }
        else if (_doorGameObject.transform.position == _closedPosition.transform.position)
        {
            _isClosing = false;
            _isClosed = true;
        }
    }

    public void OpenDoor()
    {
        _isOpening = true;
    }

    public void CloseDoor()
    {
        _isClosing = true;
    }
}
