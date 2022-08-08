using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandProcessor))]
public class EnemyController : MonoBehaviour, IActor
{
    public bool tester = false;

    public Transform player;
    public Vector3 direction;
    public Transform movePoint;

    private CommandProcessor _commandProcessor;
    private void Awake()
    {
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Update()
    {
        if (!tester)
        {
            if (player.position.x != transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);

                direction = new Vector3(0, 0, 0f);
                if (direction != Vector3.zero)
                {
                    var moveCommand = new MoveCommand(this, direction, movePoint);
                    _commandProcessor.ExecuteCommand(moveCommand);
                }
                tester = true;
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
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawRay(transform.position, -transform.up * 10);
    //}
}
