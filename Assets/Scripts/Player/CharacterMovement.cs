using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Animator anim;
    
    [Tooltip("Speed for player moving right and left")]
    public float Speed = 10f;

    [HideInInspector]public float laneSwitchTimer;
    
    
    [Tooltip("Place each node at the preferred location in the scene. Assign respective gameobject here.")]
    [Header("Nodes for player position")]
    public Transform NodeLeft; 
    public Transform NodeMiddle; 
    public Transform NodeRight;
    
   [HideInInspector] public Transform currentNode;
   [HideInInspector] public Transform previousNode;
    public enum Position
    {
        Left,
        Middle,
        Right
    };
    
    [HideInInspector] public Position currentPosition;
    [HideInInspector] public Position previousPosition;
    
    void Start()
    {
        currentPosition = Position.Middle;
        currentNode = NodeMiddle;
        previousNode = currentNode;
        previousPosition = currentPosition;
    }
    
    void Update()
    {
       getKeyInput();

       laneSwitchTimer -= Time.deltaTime;

       if (laneSwitchTimer < 0f)
           laneSwitchTimer = 0f;
    }

    public void getKeyInput()
    {
        anim.SetInteger("Move Direction", 0);
        
        anim.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));

        
        if (Input.GetKeyDown(KeyCode.A) && laneSwitchTimer <= 0f)
        {
            anim.SetInteger("Move Direction", -1);

            laneSwitchTimer = 0f;
            
            previousPosition = currentPosition;
            currentPosition -= 1;
            if (Convert.ToInt32(currentPosition) < 0)
            {
                currentPosition = Position.Left; 
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && laneSwitchTimer <= 0f)
        {
            anim.SetInteger("Move Direction", 1);

            laneSwitchTimer = 0f;
            
            previousPosition = currentPosition;
            currentPosition += 1; 
            if (Convert.ToInt32(currentPosition) > 2)
            {
                currentPosition = Position.Right; 
            }
        }

        switch (currentPosition)
        {
            case Position.Left: currentNode = NodeLeft; 
                break;
            case Position.Middle: currentNode = NodeMiddle;
                break;
            case Position.Right: currentNode = NodeRight; 
                break;
        }
        
        switch (previousPosition)
        {
            case Position.Left: previousNode = NodeLeft; 
                break;
            case Position.Middle: previousNode = NodeMiddle;
                break;
            case Position.Right: previousNode = NodeRight; 
                break;
        }
        MovePlayer();
    }

    public void MovePlayer()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(currentNode.position.x, transform.position.y,currentNode.position.z), Speed * Time.deltaTime);
    }

    private void OnValidate()
    {
        if (!(Speed > 0))
        {
            Debug.LogWarning("Speed in Character movement should be a value higher than 0");
        }
    }
}
