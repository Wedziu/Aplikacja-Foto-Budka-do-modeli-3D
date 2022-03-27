using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera camera1;
    [SerializeField] float maxZoomOut = -20f;
    [SerializeField] float maxZoomIn = -2f;
    [SerializeField] float zoomSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        camera1 = GetComponent<Camera>();
    }
    void Zooming()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && camera1.transform.position.z>maxZoomOut)
        {
           camera1.transform.position = transform.position + new Vector3(0, 0, -zoomSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && camera1.transform.position.z < maxZoomIn)
        {
            camera1.transform.position = transform.position + new Vector3(0, 0, zoomSpeed * Time.deltaTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Zooming();
    }
}
