using UnityEngine;

public interface IActor
{
    Transform transform { get; }
    void MoveFromTo(Vector3 startPos, Vector3 endPos);
}
