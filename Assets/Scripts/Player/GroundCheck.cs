using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundCheck : MonoBehaviour
{

    public Animator animator;

    [HideInInspector]public bool onWater;

    public float lerpSpeed = 10f;
    
    [HideInInspector] public float fallSpeed;
    
    [Tooltip("The highest fall speed player can reach")]
    public float maxFall;
    [Tooltip("Player weight. Affects the player's fall speed")]
    public float weight;
    [Tooltip("Player offset from water i y")]
    public float offset;
    public LayerMask groundLayer;
    [Tooltip("Force upward for player jump. Should always be negative.")]
    [FormerlySerializedAs("JumpaForce")] public float JumpForce = -20f;

    [Header("Linecast objects")]
    [Tooltip("Start of linecast for player ground check")]
    public Transform startCheck;
    [Tooltip("End of linecast for player ground check")]
    public Transform endCheck;

    private RaycastHit hit;
    
    void Update()
    {
        //drar en check-linje mellan spelarens startcheck och endcheck (midjan och brädan)
        if(Physics.Linecast(startCheck.position, endCheck.position, out hit, groundLayer) && fallSpeed >= 0f)
        {
            fallSpeed = 0f;
            //lerpar spelaren till hit-point i y-led (vattnets yta). Om spelaren skulle åka förbi hitpoint så blir det snyggt att den lerpar tillbaka. 
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, hit.point.y + offset, transform.position.z), lerpSpeed * Time.deltaTime);
            onWater = true;
            
            if (hit.transform.gameObject.tag == "Obstacle Block")
            {
                animator.SetBool("Hard Surface", true);
            }
            else
            {
                animator.SetBool("Hard Surface", false);
            }
        }
        else
        {
            fallSpeed = Mathf.Lerp(fallSpeed, maxFall, weight * Time.deltaTime);
            onWater = false;
            animator.SetBool("Hard Surface", false);
        }
        
        transform.Translate((Vector3.down * fallSpeed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) && onWater)
        {
            animator.SetBool("Jump", true);
        }

        animator.SetBool("On Water", onWater);

    }

    private void OnValidate()
    {
        if (JumpForce >= 0)
        {
            Debug.LogWarning("JumpForce in GroundCheck (script) should be a negative value");
        }

        if (maxFall <= 0)
        {
            Debug.LogWarning("maxFall in GroundCheck (script) should be a positive value");
        }
        if (weight <= 0)
        {
            Debug.LogWarning("weight in GroundCheck (script) should be a positive value");
        }
    }
}
