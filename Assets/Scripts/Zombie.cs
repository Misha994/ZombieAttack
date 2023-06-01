using UnityEngine;
using UnityEngine.AI;

public class Zombie : Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private NavMeshAgent agent;

    private Transform player;

    private void FixedUpdate()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public override void SetPlayerPosition(Transform position)
    {
        player = position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            other.gameObject.GetComponent<IDamageable>().ReduceHealth(damage);
        }
    }
}
