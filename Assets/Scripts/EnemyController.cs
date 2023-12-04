using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

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

    public GameObject gameOverMenu;
    private float distanceFromCamera = 2.0f;
    private float yOffset = 0.0f;
    public bool isActive;

    private int maxHP;
    private int hp;
    public TextMeshProUGUI hpText;

    private float randomAttackThreshold;

    void Start()
    {
        animation = GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0;
        maxHP = 5;
        hp = 5;
        gameOverMenu.SetActive(false);
        heartbeatAudioSource.gameObject.SetActive(false);
        Time.timeScale = 1;
        isActive = false;
    }

    void Update()
    {
        UpdateHPText();
        agent.SetDestination(player.position);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        float t = Mathf.InverseLerp(minDistance, maxDistance, distanceToPlayer);
        float pitch = pitchCurve.Evaluate(t);
        float volume = volumeCurve.Evaluate(t);

        heartbeatAudioSource.pitch = pitch;
        heartbeatAudioSource.volume = volume;

        if (distanceToPlayer <= maxDistance)
        {
            heartbeatAudioSource.gameObject.SetActive(true);
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

        if (distanceToPlayer <= detectionRange)
        {
            if (hp > 0 && !isAttacking)
            {
                StartCoroutine(DelayedAction());
            }
        }
        else
        {
            animation.CrossFade("Run", 1f);
            isAttacking = false;
        }
        if (hp <= 0 && !isActive)
        {
            Transform cameraTransform = Camera.main.transform;
            Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera + new Vector3(0, yOffset, 0);
            gameOverMenu.transform.position = new Vector3(targetPosition.x, cameraTransform.position.y + yOffset, targetPosition.z);

            gameOverMenu.transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);

            gameOverMenu.SetActive(true);
            isActive = true;
            Time.timeScale = 0;
        }
    }

    IEnumerator DelayedAction()
    {
        isAttacking = true;
        randomAttackThreshold = Random.Range(0f, 1f);
        string animationName = (randomAttackThreshold < 0.5f) ? "Attack1" : "Attack2";
        animation.CrossFade(animationName, 1f);
        hp -= 1;

        yield return new WaitForSeconds(2.5f);

        isAttacking = false;
    }

    void UpdateHPText()
    {
        hpText.text = "HP: " + hp.ToString() + "/" + maxHP.ToString();
    }
}
