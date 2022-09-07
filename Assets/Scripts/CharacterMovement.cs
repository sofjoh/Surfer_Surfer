using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float Speed = 10f; 
    
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
    }

    public void getKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            previousPosition = currentPosition;
            currentPosition -= 1;
            if (Convert.ToInt32(currentPosition) < 0)
            {
                currentPosition = Position.Left; 
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
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
}
