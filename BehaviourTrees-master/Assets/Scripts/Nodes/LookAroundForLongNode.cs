using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LookAroundForTooLongNode : Node
{
    private float lookDuration;
    private float elapsedTime;
    private Transform transform;

    public LookAroundForTooLongNode(float lookDuration, Transform transform)
    {
        this.lookDuration = lookDuration;
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime < lookDuration)
        {
            transform.Rotate(0, Random.Range(0, 360) * Time.deltaTime, 0);
            return NodeState.RUNNING;
        }

        elapsedTime = 0;
        return NodeState.SUCCESS;
    }
}
