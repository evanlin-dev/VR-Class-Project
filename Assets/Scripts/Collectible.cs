
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    // Update is called once per frame
    public static event Action OnCollected;

    public AudioSource collection;
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collection.clip, transform.position);
            OnCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
