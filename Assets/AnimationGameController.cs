using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGameController : MonoBehaviour
{

    public GroundCheck gCheck;

    void Update()
    {
        
    }

    void Jump()
    {
        gCheck.fallSpeed = gCheck.JumpaForce;
        GetComponent<Animator>().SetBool("Jump", false);
    }

}
