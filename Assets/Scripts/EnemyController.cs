using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public float detectionRange = 1f;
    private Animation animation;
    private bool isAttacking = false;

    private void Start()
    {
        animation = GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0;
    }

    private void Update()
    {
        agent.SetDestination(player.position);

        // Calculate the distance between the enemy and the player.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the detection range.
        if (distanceToPlayer <= detectionRange)
        {
            // Player is in range. Choose between animations randomly.
            float randomValue = Random.Range(0f, 1f);
            if (randomValue < 0.5f) {
                // Crossfade to the "Attack1" animation with a smooth transition
                animation.CrossFade("Attack1", 1f);
            }
            else {
                // Crossfade to the "Attack2" animation with a smooth transition
                animation.CrossFade("Attack2", 1f);
            }

            // You can add attack behavior here (e.g., dealing damage to the player).
            if (!isAttacking)
            {
                isAttacking = true;
                // Implement your attack logic here.
            }
        }
        else
        {
            // Player is out of range. Stop the attack animation.
            animation.CrossFade("Run", 1f);

            // Reset the attack state.
            isAttacking = false;
        }
    }
}
