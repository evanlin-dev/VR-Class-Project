using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    // Start is called before the first frame update
    TMPro.TMP_Text text;
    int count;

    public GameObject finishObject;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        finishObject.SetActive(false);
    }

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        text.text = "Keys: " + (++count).ToString() + " / 8";
        if (count == 8)
        {
            // When count reaches 8, make the "Finish" object visible
            finishObject.SetActive(true);
        }
    }

}
