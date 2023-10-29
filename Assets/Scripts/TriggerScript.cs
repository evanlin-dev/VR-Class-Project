using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject monster;
    private void OnTriggerEnter(Collider other)
    {
        monster.active = true;
    }
}