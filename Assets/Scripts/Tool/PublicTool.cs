using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicTool : MonoBehaviour
{
    public static void ClearChildItem(UnityEngine.Transform tf)
    {
        foreach (UnityEngine.Transform item in tf)
        {
            UnityEngine.Object.Destroy(item.gameObject);
        }
    }

    /// <summary>
    /// Useful function for Calculate angle. For example, from Target to (0,1)
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static float CalculateAngle(Vector2 from, Vector2 to)
    {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? angle : -angle;
    }
}
