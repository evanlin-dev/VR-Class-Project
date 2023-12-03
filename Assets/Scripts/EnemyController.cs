using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public float detectionRange = 1f;
    private Animation animation;
    private bool isAttacking = false;
    public AudioSource heartbeatAudioSource;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public AnimationCurve pitchCurve;
    public AnimationCurve volumeCurve;

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

        float t = Mathf.InverseLerp(minDistance, maxDistance, distanceToPlayer);
        float pitch = pitchCurve.Evaluate(t);
        float volume = volumeCurve.Evaluate(t);

        // Set the pitch and volume of the heartbeat sound.
        heartbeatAudioSource.pitch = pitch;
        heartbeatAudioSource.volume = volume;

        // Play or stop the heartbeat sound based on distance.
        if (distanceToPlayer <= maxDistance)
        {
            if (!heartbeatAudioSource.isPlaying)
            {
                heartbeatAudioSource.Play();
            }
        }
        else
        {
            if (heartbeatAudioSource.isPlaying)
            {
                heartbeatAudioSource.Stop();
            }
        }

        // Handle animations as needed.
        if (distanceToPlayer <= detectionRange)
        {
            float randomValue = Random.Range(0f, 1f);
            string animationName = (randomValue < 0.5f) ? "Attack1" : "Attack2";
            animation.CrossFade(animationName, 1f);

            if (!isAttacking)
            {
                isAttacking = true;
                // Implement your attack logic here.
            }
        }
        else
        {
            animation.CrossFade("Run", 1f);

            // Reset the attack state.
            isAttacking = false;
        }
    }
}
