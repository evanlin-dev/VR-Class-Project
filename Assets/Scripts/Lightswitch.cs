using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lightswitch : MonoBehaviour
{

    [SerializeField] public GameObject roomLight;
    public GameObject buttons;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;


    private void Start()
    {

        sound = GetComponent<AudioSource>();
        isPressed = false;   
    }

    private void OnTriggerEnter(Collider other){
        if(!isPressed){
            buttons.transform.localPosition = new Vector3(0, 0, 0);
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other == presser){
            buttons.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void flipSwitch(){
        roomLight.SetActive(!roomLight.activeSelf);
    }

}