using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform gate;
    private NavMeshAgent agent;
    private Rikayon rikayon;
    private int distanceAttack = 10;

    private int tempHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rikayon = GetComponent<Rikayon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        float distancePlayer = Vector3.Magnitude(player.position - position);
        float distanceGate = Vector3.Magnitude(gate.position - position);
        agent.destination = player.position;
        if (distancePlayer <= distanceGate)
        {
            if(distancePlayer < distanceAttack)
            {
                Attack();
            }
        }
        else
        {
            agent.destination = gate.position;
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
        rikayon.Attack1();
    }

    public void Damaged(int dmgValue)
    {
        tempHealth -= dmgValue;

        if (tempHealth <= 0)
        {
            agent.isStopped = true;
            rikayon.Dead();
        }
        else
        {
            rikayon.TakeDamage();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
