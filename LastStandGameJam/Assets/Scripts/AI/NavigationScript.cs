using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    private Transform _player;
    private Transform _gate;
    private NavMeshAgent _agent;
    private Rikayon _rikayon;

    [SerializeField] private int _distanceAttack = 5;
    [SerializeField] private int _tempHealth = 10;


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
        if (_tempHealth >= 0)
        {
            Vector3 position = transform.position;
            float distancePlayer = Vector3.Magnitude(_player.position - position);
            float distanceGate = Vector3.Magnitude(_gate.position - position);
            _agent.destination = _player.position;
            if (distancePlayer <= distanceGate)
            {
                if (distancePlayer < _distanceAttack)
                {
                    _rikayon.CanWalk();
                    transform.forward = _player.position - transform.position;
                    Attack();
                }
                else
                {
                    _rikayon.Walk();
                    _rikayon.CanAttack();
                }
            }
            else
            {
                _rikayon.Walk();
                _agent.destination = _gate.position;
            }
        }
        else
        {
            _rikayon.Dead();
        }
    }

    private void Attack()
    {
        _rikayon.Attack1();
    }

    public void Damaged(int dmgValue)
    {
        Debug.Log("Touche");
        _tempHealth -= dmgValue;

        if (_tempHealth <= 0)
        {
            _rikayon.ResetAnimBool();
            _agent.isStopped = true;
            _rikayon.Dead();
        }
        else
        {
            _rikayon.TakeDamage();
            _rikayon.ResetAnimBool();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
