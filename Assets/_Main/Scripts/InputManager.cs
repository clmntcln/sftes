using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    enum EAbilities { MOVE, ATTACK, SPECIAL };

    bool trackCursor = false;

    public Vector3 cursorPos = new Vector3(0, 0, 0);


    int groundLayer;

    // Start is called before the first frame update
    void Start()
    {

        groundLayer = LayerMask.GetMask("Ground");
        
    }

    // Update is called once per frame
    void Update()
    {

        if(trackCursor){
            //Raycast on ground to get target position

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.blue);

                cursorPos = hit.point;
            }
        }
        
    }

    void SetCursorTracking(bool state)
    {

        trackCursor = state;

    }

    void CheckAbilitiesInput(){

        //Check if player wants to launch ability
        //Communicates info to crew manager 
        //Crew manager dispatches info to current crew member selected

    }
}
