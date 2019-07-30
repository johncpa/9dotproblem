using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProblemTry {

    [SerializeField]
    public List<Vector2> points; // 0-8 points in space

    public ProblemTry(List<Vector2> myPoints)
    {
        if(myPoints.Count > 8)
        {
            throw new System.Exception("Too many points! Should be max 2 * 4");
        }
        points = myPoints;
    }
}
