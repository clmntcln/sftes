using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portrait : MonoBehaviour
{
    [Header("Temp")]
    public Color color;

    [Header("Character")]
    public Sprite faceSpriteSource;

    GameObject bgActive;
    Image faceImageContainer;

    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {

        bgActive = transform.Find("bg--active").gameObject;
        faceImageContainer = transform.Find("face").GetComponent<Image>();

        if(faceSpriteSource != null){
            faceImageContainer.sprite = faceSpriteSource;
        } else {
            faceImageContainer.color = color;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelected(bool state)
    {
        selected = state;

        bgActive.SetActive(state);

    }

}
