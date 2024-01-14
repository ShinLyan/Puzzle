using System.Collections.Generic;
using UnityEngine;

public class BezierViz : MonoBehaviour
{
    public List<Vector2> ControlPoints;
    public GameObject PointPrefab;

    public float LineWidth;
    public float LineWidthBezier;
    public Color LineColour = new Color(0.5f, 0.5f, 0.5f, 0.8f);
    public Color BezierCurveColour = new Color(0.5f, 0.6f, 0.8f, 0.8f);
    public Color BezierCurveColour2 = new Color(0.8f, 0.6f, 0.5f, 0.8f);

    private LineRenderer[] mLineRenderers;
    private List<GameObject> mPointGameObjects = new List<GameObject>();

    private LineRenderer CreateLine()
    {
        var obj = new GameObject();
        LineRenderer lr = obj.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = LineColour;
        lr.endColor = LineColour;
        lr.startWidth = LineWidth;
        lr.endWidth = LineWidth;
        return lr;
    }

    private void Start()
    {
        // Create the two LineRenderers.
        mLineRenderers = new LineRenderer[2];
        mLineRenderers[0] = CreateLine();
        mLineRenderers[1] = CreateLine();

        // Set a name to the game objects for the LineRenderers to distingush them.
        mLineRenderers[0].gameObject.name = "LineRenderer_obj_0";
        mLineRenderers[1].gameObject.name = "LineRenderer_obj_1";

        // Create the instances of PointPrefab to show the control points.
        for (int i = 0; i < ControlPoints.Count; ++i)
        {
            GameObject obj = Instantiate(PointPrefab, ControlPoints[i], Quaternion.identity);
            obj.name = "ControlPoint_" + i.ToString();
            mPointGameObjects.Add(obj);
        }
    }

    private void Update()
    {
        LineRenderer lineRenderer = mLineRenderers[0];
        LineRenderer curveRenderer = mLineRenderers[1];

        var pts = new List<Vector2>();

        for (int k = 0; k < mPointGameObjects.Count; ++k)
        {
            pts.Add(mPointGameObjects[k].transform.position);
        }

        // Create a line renderer for showing the straight lines between control points.
        lineRenderer.positionCount = pts.Count;
        for (int i = 0; i < pts.Count; ++i)
        {
            lineRenderer.SetPosition(i, pts[i]);
        }

        // We take the control points from the list of points in the scene.
        // Recalculate points every frame.
        List<Vector2> curve = BezierCurve.PointList2(pts, 0.01f);
        curveRenderer.startColor = BezierCurveColour;
        curveRenderer.endColor = BezierCurveColour;
        curveRenderer.positionCount = curve.Count;
        for (int i = 0; i < curve.Count; ++i)
        {
            curveRenderer.SetPosition(i, curve[i]);
        }
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isMouse)
        {
            if (e.clickCount == 2 && e.button == 0)
            {
                var rayPos = new Vector2(
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                InsertNewControlPoint(rayPos);
            }
        }
    }

    private void InsertNewControlPoint(Vector2 p)
    {
        if (mPointGameObjects.Count >= 16)
        {
            Debug.Log("Cannot create any new control points. Max number is 16");
            return;
        }
        GameObject obj = Instantiate(PointPrefab, p, Quaternion.identity);
        obj.name = "ControlPoint_" + mPointGameObjects.Count.ToString();
        mPointGameObjects.Add(obj);
    }
}
