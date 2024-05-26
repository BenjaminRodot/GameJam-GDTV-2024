using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private float _spawnTimer;

    [SerializeField]
    private int _spawnRepetition;

    [SerializeField]
    private bool _isIndestructible;

    private float _currentTimer;
    private int _currentRepetition;
    private bool _hasStarted;

    public bool HasStarted => _hasStarted;
    public bool IsIndestructible => _isIndestructible;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!HasStarted)
        {
            return;
        }

        if (_currentTimer >= _spawnTimer)
        {
            Instantiate(_prefab,this.gameObject.transform);
            _currentRepetition++;
            _currentTimer = 0;
        }

        if(!_isIndestructible && _currentRepetition == _spawnRepetition)
        {
            DestroySpawn();
        }

        _currentTimer += Time.deltaTime;
    }

    private void DestroySpawn()
    {
        Destroy(this.gameObject);
    }

    public void StartTimer()
    {
        if (!HasStarted)
        {
            _hasStarted = true;
        }
    }

    public void StopTimer()
    {
        if (HasStarted)
        {
            _hasStarted = false;
            _currentTimer = 0;
        }
    }
}
