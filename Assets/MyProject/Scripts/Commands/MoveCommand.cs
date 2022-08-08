using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _directionActorMovement;
    private Transform _movePoint;
    public MoveCommand(IActor actor, Vector3 directionActorMovement, Transform movePoint) : base(actor)
    {
        _directionActorMovement = directionActorMovement;
        _movePoint = movePoint;
    }

    public override void Execute()
    {
        //_actor.transform.position = Vector3.MoveTowards(_actor.transform.position, _movePoint.position, 5 * Time.deltaTime);

        Debug.Log("Moving");
        _movePoint.position += _directionActorMovement;

    }

    public override void Undo()
    {
        //_actor.transform.position = Vector3.MoveTowards(_actor.transform.position, _movePoint.position, 5 * Time.deltaTime);

        _movePoint.position -= _directionActorMovement;

    }
}
