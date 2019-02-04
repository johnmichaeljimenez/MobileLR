using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class Utils
{

    public static void SetOnClickListener(this Button b, UnityAction a)
    {
        b.onClick.RemoveAllListeners();
        b.onClick.AddListener(a);
    }

    public static bool BetweenLineAndCircle(
     Vector2 circleCenter, float circleRadius,
     Vector2 point1, Vector2 point2)
    {
        if ((point1-circleCenter).magnitude <= circleRadius && (point2-circleCenter).magnitude <= circleRadius)
        {
            return true;
        }

		Vector2 intersection1, intersection2;
        float t;

        var dx = point2.x - point1.x;
        var dy = point2.y - point1.y;

        var a = dx * dx + dy * dy;
        var b = 2 * (dx * (point1.x - circleCenter.x) + dy * (point1.y - circleCenter.y));
        var c = (point1.x - circleCenter.x) * (point1.x - circleCenter.x) + (point1.y - circleCenter.y) * (point1.y - circleCenter.y) - circleRadius * circleRadius;

        var determinate = b * b - 4 * a * c;
        if ((a <= 0.0000001) || (determinate < -0.0000001))
        {
            // No real solutions.
            intersection1 = Vector2.zero;
            intersection2 = Vector2.zero;
            return false;
        }
        if (determinate < 0.0000001 && determinate > -0.0000001)
        {
            // One solution.
            t = -b / (2 * a);
            if (t >= 0 && t <= 1)
                return true;
            intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
            intersection2 = Vector2.zero;
            return false;
        }

        // Two solutions.
        t = (float)((-b + Mathf.Sqrt(determinate)) / (2 * a));
		if (t >= 0 && t <= 1)
			return true;
        intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
        
        t = (float)((-b - Mathf.Sqrt(determinate)) / (2 * a));
		if (t >= 0 && t <= 1)
			return true;
        intersection2 = new Vector2(point1.x + t * dx, point1.y + t * dy);

        return false;
    }

}
