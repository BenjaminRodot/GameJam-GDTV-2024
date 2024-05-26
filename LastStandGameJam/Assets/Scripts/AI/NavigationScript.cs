using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    private Transform _player;
    private Transform _gate;
    private NavMeshAgent _agent;
    private Rikayon _rikayon;
    private int _distanceAttack = 5;

    private int _tempHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rikayon = GetComponent<Rikayon>();
        _player = GameObject.FindWithTag("Player").transform;
        _gate = GameObject.FindWithTag("Gate").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        float distancePlayer = Vector3.Magnitude(_player.position - position);
        float distanceGate = Vector3.Magnitude(_gate.position - position);
        _agent.destination = _player.position;
        if (distancePlayer <= distanceGate)
        {
            if(distancePlayer < _distanceAttack)
            {
                _rikayon.CanWalk();
                transform.forward = _player.position-transform.position;
                Attack();
            }
            else
            {
                _rikayon.CanAttack();
                _rikayon.Walk();
            }
        }
        else
        {
            _agent.destination = _gate.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damaged(4);
        }
    }

    private void Attack()
    {
        _rikayon.Attack1();
    }

    public void Damaged(int dmgValue)
    {
        _tempHealth -= dmgValue;

        if (_tempHealth <= 0)
        {
            _agent.isStopped = true;
            _rikayon.Dead();
        }
        else
        {
            _rikayon.TakeDamage();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
