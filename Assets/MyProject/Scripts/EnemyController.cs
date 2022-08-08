using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandProcessor))]
public class EnemyController : MonoBehaviour, IActor
{
    public Transform player;
    public Vector3 direction;
    public Transform movePoint;

    private CommandProcessor _commandProcessor;
    private float moveSpeed = 5f;

    private void Awake()
    {
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (player.position.x < transform.position.x)
            {
                direction = new Vector3(-1, 0, 0);
            }
            else if (player.position.x > transform.position.x)
            {
                direction = new Vector3(1, 0, 0);
            }
            else if(player.position.x == transform.position.x + 1|| player.position.x == transform.position.x - 1) 
            {
                Debug.Log("Stop moving. Player infront of me");
                direction = Vector3.zero;
            }
            if (direction != Vector3.zero)
            {
                var moveCommand = new MoveCommand(this, direction, movePoint);
                _commandProcessor.ExecuteCommand(moveCommand);
            }

        }


        //RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, -transform.up * 10);

        //if (hitinfo)
        //{
        //    Debug.Log("hit sth");
        //}
    }

    public void MoveFromTo(Vector3 startPos, Vector3 endPos)
    {
        throw new System.NotImplementedException();
    }
}
