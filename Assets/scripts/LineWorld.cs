using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWorld : MonoBehaviour {

	private static LineWorld _main;
	public static LineWorld main
	{
		get{
			if (!_main)
				_main = GameObject.FindObjectOfType<LineWorld>();

			return _main;
		}
	}

	public List<Line> lines;

	public GameObject linePrefab;

	void Start () {
		DrawLines();
	}
	
	void Update () {
		
	}

	public void AddLine(Vector2 v1, Vector3 v2)
	{
		Line l = new Line(v1, v2);
		lines.Add(l);
		DrawLines();
	}

	public void RemoveLine(Vector2 erasePoint, float radius)
	{
		for (int i = lines.Count - 1; i >= 0 ; i--)
		{
			Line l = lines[i];
			Vector3 v1 = Camera.main.WorldToScreenPoint(l.start);
			Vector3 v2 = Camera.main.WorldToScreenPoint(l.end);
			bool e = Utils.BetweenLineAndCircle(erasePoint, radius, v1, v2);

			if (!e)
				continue;

			lines.Remove(l);
			Destroy(transform.GetChild(i).gameObject);
		}

		HUD.main.ShowEraser(erasePoint);
	}

	public void ClearLine()
	{

	}

	public void DrawLines()
	{
		for (int i = transform.childCount - 1; i >= 0 ; i--)
		{
			Destroy(transform.GetChild(i).gameObject);
		}

		foreach (Line i in lines)
		{
			i.Compute();

			GameObject g = Instantiate(linePrefab);
			g.transform.SetParent(transform, false);
			g.transform.localPosition = i.midPoint;
			g.transform.localEulerAngles = Vector3.forward * i.rotation;

			LineRenderer r = g.GetComponent<LineRenderer>();
			r.SetPosition(0, Vector3.left * (i.length/2));
			r.SetPosition(1, Vector3.right * (i.length/2));

			BoxCollider2D b = g.GetComponent<BoxCollider2D>();
			b.size = new Vector3(i.length, 0.05f);
		}
	}
}

[System.Serializable]
public class Line
{
	public Vector2 start, end, midPoint, offset;

	public float rotation;
	public float length;


	public Line(Vector2 v1, Vector2 v2)
	{
		start = v1;
		end = v2;

		Compute();
	}

	public void Compute()
	{
		midPoint = (end-start);
		rotation = Mathf.Atan2(midPoint.y, midPoint.x) * Mathf.Rad2Deg;
		length = midPoint.magnitude;

		midPoint = (start+end)/2;
	}
}