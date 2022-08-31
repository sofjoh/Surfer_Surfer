using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float Speed = 10f; 
    public Transform NodeLeft; 
    public Transform NodeMiddle; 
    public Transform NodeRight;
    private Transform currentNode;
    public float JumpForce = 5f; 
    public enum Position
    {
        Left,
        Middle,
        Right
    };
    
    Position currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = Position.Middle;
    }

    // Update is called once per frame
    void Update()
    {
        getKeyInput();
    }
    
    public void getKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentPosition -= 1;
            if (Convert.ToInt32(currentPosition) < 0)
            {
                currentPosition = Position.Left; 
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
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
        
        transform.position = Vector3.Lerp(transform.position, currentNode.position, Speed * Time.deltaTime);
    }
}
