using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightonoff : MonoBehaviour
{
    
    private bool PlayerInZone;                  //check if the player is in trigger

    public GameObject lightorobj;

    private void Start()
    {

        PlayerInZone = false;                   //player not in zone       
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.F))           //if in zone and press F key
        {
            lightorobj.SetActive(!lightorobj.activeSelf);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("switch");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            PlayerInZone = true;
        }
     }
    

    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
        }
    }
}