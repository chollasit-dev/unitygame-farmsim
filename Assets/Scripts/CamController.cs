using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private float minZoomDistance;
    [SerializeField] private float maxZoomDistance;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomModifier;

    private Camera cam;
    public static CamController instance;
    void Start()
    {
        instance = this;
        cam = Camera.main;  // Call cam Utilize Less Load than Camera.main
    }

    void Update()
    {

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
}
