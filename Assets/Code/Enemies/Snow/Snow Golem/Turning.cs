using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UIElements;

public class Turning : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
