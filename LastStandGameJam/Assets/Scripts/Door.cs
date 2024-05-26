using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour
{
    protected bool _isClosed;
    protected bool _isOpening;
    protected bool _isClosing;
    public bool IsClosed => _isClosed;
    public bool IsOpening => _isOpening;
    public bool IsClosing => _isClosing;
    public abstract void OpenDoor();
    public abstract void CloseDoor();
}
