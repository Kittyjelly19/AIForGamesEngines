﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Profiler.BeginSample("Alignment - CalculateMove()");
        if (context.Count == 0) // No neighbours, maintain current alignment
        {
            return agent.transform.up;
        }

        // Add all points and average out
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context); // Determines if there is a filter placed on this behaviour
        foreach (Transform item in filteredContext)
        {
            alignmentMove += item.transform.up;
        }
        alignmentMove /= context.Count;

        Profiler.EndSample();
        return alignmentMove;
    }
}
