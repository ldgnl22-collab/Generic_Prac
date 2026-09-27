using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Stack<Vector3> movementStack = new Stack<Vector3>();
    
    float _moveSpeed = 5f;

    private void Awake() => Init();
    
    private void Update()
    {
        Move();
        UndoMovePos();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(h, 0f, v).normalized;
        
        // transform.Translate(dir * Time.deltaTime);
        transform.position += dir;
        movementStack.Push(transform.position);
    }

    private void UndoMovePos()
    {
        if (movementStack == null) return;
        
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 dir = new Vector3(movementStack.Pop().x, 0f, movementStack.Pop().z);
            transform.Translate(dir * _moveSpeed * Time.deltaTime);
            
            
        }
    }

    private void Init()
    {
        movementStack.Clear();
        movementStack.Push(transform.position);
    }
}
