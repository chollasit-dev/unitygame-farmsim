using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private float minZoomDistance;
    [SerializeField] private float maxZoomDistance;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomModifier;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform corner1, corner2;
    private Camera cam;
    public static CamController instance;
    void Start()
    {
        instance = this;
        cam = Camera.main;  // Call cam Utilize Less Load than Camera.main
    }

    void Update()
    {
        Zoom();
        MoveByKey();
    }

    private void Zoom()
    {
        zoomModifier = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetKey(KeyCode.Z))    //Hold Z
        {
            zoomModifier = 0.01f;
        }
        if (Input.GetKey(KeyCode.X))
        {
            zoomModifier = -0.01f;
        }

        float distance = Vector3.Distance(transform.position, cam.transform.position);  //CamBase, cam pos.
        if (distance < minZoomDistance && zoomModifier > 0f)
            return;
        else if (distance > maxZoomDistance && zoomModifier < 0f)
            return;

        cam.transform.position += cam.transform.forward * zoomModifier * zoomSpeed;
    }

    private void MoveByKey()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;
        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.position = Clamp(corner1.position, corner2.position);
    }

    private Vector3 Clamp(Vector3 lowerLeft, Vector3 topRight)
    {
        Vector3 pos = new Vector3(Mathf.Clamp(
            transform.position.x, lowerLeft.x, topRight.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, lowerLeft.z, topRight.z));
        return pos;
    }
}
