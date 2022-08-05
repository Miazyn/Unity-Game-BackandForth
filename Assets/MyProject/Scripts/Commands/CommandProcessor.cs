using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> _commands = new List<Command>();
    private int _curCommandIndex;

    public void ExecuteCommand(Command command)
    {
        _commands.Add(command);
        command.Execute();
        _curCommandIndex = _commands.Count - 1;

    }


    public void Undo()
    {
        if (_curCommandIndex < 0)
        {
            return;
        }

        _commands[_curCommandIndex].Undo();
        _commands.RemoveAt(_curCommandIndex);
        _curCommandIndex--;

    }

    public void Redo()
    {

        _commands[_curCommandIndex].Execute();
        _curCommandIndex++;

    }
}
