using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember : MonoBehaviour
{

    [Range(1, 10)]
    public float speed = 1.0f;

    //Ability[] abilities = new Ability[3];
    public bool holdMove = false;
    public bool holdAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 target){
        
        //Time needs to be a factor of speed
        iTween.MoveTo(transform.gameObject, target, 3);

        //Activate cooldown

    }
}
