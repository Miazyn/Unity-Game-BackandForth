using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected IActor _actor;

    public Command(IActor actor)
    {
        _actor = actor;
    }

    public abstract void Execute();
    public abstract void Undo();
}
