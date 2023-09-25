using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player; 

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

private void Update()
{
    // Debug.Log("Player Position: " + player.position);
    // Debug.Log("Agent Destination: " + agent.destination);
    agent.SetDestination(player.position);
}

}
