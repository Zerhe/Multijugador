using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseInput 
{
    public static RaycastHit hit;
    public static RaycastHit2D hit2D;
    public static float maxDistanceRay = 100;

    public static Vector3 MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Camera.main.transform.position.y + maxDistanceRay))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
    public static Collider MouseColission()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDistanceRay))
        {         
            return hit.collider;
        }
        return null;
    }
    public static Collider2D MouseColission2D()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (hit2D = Physics2D.Raycast( ray.origin,ray.direction, maxDistanceRay))
        {
            return hit2D.collider;
        }
        return null;
    }
}
