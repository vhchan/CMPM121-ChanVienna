using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent_Movement : MonoBehaviour
{

    private Vector3 targetPos;

    private float speed = 15.0f;
    public float gravity = -9.8f;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update() //opponent moves towards you to try and kill you
    {
        
        targetPos = target.transform.position;
        if (SimpleCharacterControl.countDown == false)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }    
        else
        {
            Debug.Log(transform.position);
        }
    }

}
