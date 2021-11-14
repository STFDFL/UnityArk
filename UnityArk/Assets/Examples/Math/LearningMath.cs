using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Animations;
using UnityEditor;
//using System.Numerics;
//Without using UnityEngine;


public class LearningMath : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public Transform cube;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Calculate();
        }
    }

    void Calculate()
    {
        var v1 = GetVector2Between(pointA.transform.position, pointB.transform.position);
        CreateCube(v1).gameObject.name = "v1";
        Debug.Log($"GetVector2Between: {v1}");
        Debug.Log($"-------------------------------------------------------------------------");

        var v2 = GetDistanceBetween(pointA.transform.position, pointB.transform.position);
        Debug.Log($"GetDistanceBetween: {v2}");
        Debug.Log($"-------------------------------------------------------------------------");

        var v3 = Normalise(pointA.transform.position, pointB.transform.position);
        Debug.Log($"Normalise: {v3}");
        Debug.Log($"-------------------------------------------------------------------------");

        var v4 = ScaleLine(pointA.transform.position, pointB.transform.position, 2);
        Debug.Log($"ScaleLine: {v4}");
        Debug.Log($"-------------------------------------------------------------------------");

        var v5 = LerpLine(pointA.transform.position, pointB.transform.position, 2);
        Debug.Log($"LerpLine: {v5}");
        Debug.Log($"-------------------------------------------------------------------------");

        var v6 = LerpCircle(2, pointA.transform.position, 4);
        Debug.Log($"LerpCircle: {v6}");
        Debug.Log($"-------------------------------------------------------------------------");

        var v7 = GetPolygonVerticies(pointA.transform.position, 2, 4);
        Debug.Log($"GetPolygonVerticies: {v7}");
        Debug.Log($"-------------------------------------------------------------------------");
    }

    Transform CreateCube(Vector2 pos)
    {
        return Instantiate(cube, pos, Quaternion.identity);
    }

    /// <summary>
    /// Returns a Vector2 that starts at point a and goes to point b 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    Vector2 GetVector2Between(Vector2 a, Vector2 b)
    {
        return (b - a) / 2;
    }

    /// <summary>
    /// Calculates the length (or Magnitude) of a line, given its endpoints
    /// </summary>
    /// <param name="a"></param>
    float GetDistanceBetween(Vector2 a, Vector2 b)
    {
        var dx = a.x - b.x;
        var dy = a.y - b.y;
        float root = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        return root;
    }

    /// <summary>
    /// Normalise the Vector2 that runs between a & b
    /// </summary>
    Vector2 Normalise(Vector2 a, Vector2 b)
    {
        var distance = GetDistanceBetween(pointA.transform.position, pointB.transform.position);
        //var normalized = (x - min(x)) / (max(x) - min(x))

        return Vector2.zero;
    }

    /// <summary>
    /// Returns a Vector2 that represents the vector2 between a & b at the provided scale
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    Vector2 ScaleLine(Vector2 a, Vector2 b, float scale)
    {
        return Vector2.zero;
    }

    /// <summary>
    /// Returns the relative position between a and b when an amount (between 0 & 1) is provided
    /// What is the diference between scaling a line and lerping a line?
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name=""></param>
    /// <returns></returns>
    Vector2 LerpLine(Vector2 a, Vector2 b, float amount)
    {
        return Vector2.zero;
    }

    /// <summary>
    /// Returns a Vector2 that represents a position on a circle 
    /// </summary>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    Vector2 LerpCircle(float amount, Vector2 center, float radius)
    {
        return Vector2.zero;
    }

    /// <summary>
    /// returns verticies of a variable sided shape within the provided radius at the provided position.
    /// </summary>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="sides"></param>
    List<Vector2> GetPolygonVerticies(Vector2 center, float radius, int sides)
    {
        return null;
    }

}
