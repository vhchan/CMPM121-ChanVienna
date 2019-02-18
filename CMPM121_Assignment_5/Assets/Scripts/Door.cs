using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(SimpleCharacterControl.unlock);

    }

    // Update is called once per frame
    void Update()
    {
        if (SimpleCharacterControl.unlock)
        {
            openDoor();
        }
    }

    void openDoor()
    {
        anim.Play("DoorOpen");
    }
}
