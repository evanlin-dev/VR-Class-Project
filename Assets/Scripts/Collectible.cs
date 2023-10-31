
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    // Update is called once per frame
    public static event Action OnCollected;
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
