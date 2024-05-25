using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private float _spawnTimer;

    private float _currentTimer;
    private bool _hasStarted;

    public bool HasStarted => _hasStarted;

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
            _currentTimer = 0;
        }

        _currentTimer += Time.deltaTime;
    }

    public void StartTimer()
    {
        if (!HasStarted)
        {
            _hasStarted = true;
        }
    }
}
