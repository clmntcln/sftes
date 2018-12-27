using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{

    [Header("Tail")]
    public GameObject tail;
    public Vector3 tailOffset = new Vector3();

    [Header("Head")]
    public GameObject head;
    public Vector3 headOffset = new Vector3();

    SpriteRenderer tailRenderer;

    [HideInInspector]
    public Vector3 origin = new Vector3();
    [HideInInspector]
    public Vector3 target = new Vector3();

    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {

        tailRenderer = tail.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isVisible)
        {

            tail.transform.position = origin + tailOffset;
            head.transform.position = target + headOffset;

            Vector2 originPoint = new Vector2(origin.x, origin.z);
            Vector2 targetPoint = new Vector2(target.x, target.z);

            float angle = Mathf.Atan2(targetPoint.y - originPoint.y, targetPoint.x - originPoint.x) * Mathf.Rad2Deg;
            float dist = Vector3.Distance(target, origin);

            tail.transform.rotation = Quaternion.Euler(-90, 0.0f, angle * -1);
            tailRenderer.size = new Vector2(dist, 0.16f);

        }

    }

    public void SetCursorVisibility(bool state)
    {

        isVisible = state;

        tail.SetActive(isVisible);
        head.SetActive(isVisible);

    }

    public void ToggleCursorVisibility()
    {

        isVisible = !isVisible;

        tail.SetActive(isVisible);
        head.SetActive(isVisible);

    }

}
