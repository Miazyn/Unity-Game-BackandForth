using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovementLayer;
    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Vector3 horizontalAddedMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + horizontalAddedMovement, .2f, whatStopsMovementLayer))
                {
                    movePoint.position += horizontalAddedMovement;
                }
            }
            //Disable diagonal movement by making this an else if statement.
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                Vector3 verticalAddedMovement = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + verticalAddedMovement, .2f, whatStopsMovementLayer))
                {
                    movePoint.position += verticalAddedMovement;
                }
            }
        }
    }

}
