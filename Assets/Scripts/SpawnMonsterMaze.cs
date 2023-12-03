using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monster;
    public GameObject player;
    public float activationDistance = 10f;
    private Vector3 initialMonsterPosition;

    void Start()
    {
        initialMonsterPosition = monster.transform.position;
        monster.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, initialMonsterPosition);

        if (distance <= activationDistance)
        {
            monster.SetActive(true);
        }
    }
}
