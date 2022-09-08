using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Animator animator;

    public bool onWater;

    public float lerpSpeed = 10f;
    
    public float fallSpeed;
    
    public float maxFall;
    public float weight;
    public float offset;
    public LayerMask groundLayer;
    public float JumpaForce = 3.25f;

    public bool isGrounded;

    public Transform startCheck;
    public Transform endCheck;

    private RaycastHit hit;
    
    void Update()
    {
        
        if(Physics.Linecast(startCheck.position, endCheck.position, out hit, groundLayer) && fallSpeed >= 0f)
        {
            fallSpeed = 0f;
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
}
