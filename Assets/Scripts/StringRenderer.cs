using UnityEngine;

public class StringRenderer : MonoBehaviour
{
    [SerializeField] private Transform stringConnectionPoint;

    private LineRenderer lineRenderer;
    private Transform connectedObj;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, stringConnectionPoint.position);
        lineRenderer.SetPosition(1, connectedObj.position);
    }

    public void SetConnectedObject(Transform obj)
    {
        connectedObj = obj;
    }
}
