using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;

    void Reset()
    {
        waypoints = GetComponentsInChildren<Waypoint>();
    }
}