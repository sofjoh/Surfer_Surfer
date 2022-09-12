using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGameController : MonoBehaviour
{

    [Tooltip("Wants a GameObject with the GroundCheck script. Most likely the Player object.")]
    public GroundCheck gCheck;

    void Update()
    {
        
    }

    void Jump()
    {
        gCheck.fallSpeed = gCheck.JumpForce;
        GetComponent<Animator>().SetBool("Jump", false);
    }

}
