using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 300f;
    bool dragging = false;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDrag()
    {
        dragging = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
    private void FixedUpdate()
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;
            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
            
        }
        else if(!dragging)
        {
            rb.drag = 1;
            rb.angularDrag = 1;
        }
    }
}
public class LoadAssets : MonoBehaviour
{

    public List<GameObject> assetList;
    public int CurrentObject = 0;
    public int objectIndex = 0;
    public int maxChildAmount = 1;
    public Rotation rotation;
    int listSize;
    // Start is called before the first frame update
    void Start()
    {
        assetList = new List<GameObject>(Resources.LoadAll<GameObject>("Input"));
        listSize = assetList.Count;
        GameObject var = Instantiate(assetList[0], new Vector3(0, (float)1.15, 0), Quaternion.identity, transform.gameObject.transform);
        var.AddComponent(typeof(Rotation));
        var.AddComponent<Rigidbody>();
        var.GetComponent<Rigidbody>().useGravity = false;
        Debug.Log(listSize);
        
    }

    public void NextObject()
    {
        if (objectIndex < listSize-1)
        {
            for (int i = 0; i < maxChildAmount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            objectIndex++;
            GameObject var = Instantiate(assetList[objectIndex], new Vector3(0, (float)1.15, 0), Quaternion.identity, transform.gameObject.transform);
            var.AddComponent(typeof(Rotation));
            var.AddComponent<Rigidbody>();
            var.GetComponent<Rigidbody>().useGravity = false;
        }
        else if(objectIndex==listSize-1)
        {
            for (int i = 0; i < maxChildAmount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            GameObject var = Instantiate(assetList[0], new Vector3(0, (float)1.15, 0), Quaternion.identity, transform.gameObject.transform);
            var.AddComponent(typeof(Rotation));
            var.AddComponent<Rigidbody>();
            var.GetComponent<Rigidbody>().useGravity = false;
            objectIndex = 0;
        }
        {
            return;
        }
    }
    public void PreviousObject()
    {
        if (objectIndex != 0)
        {

            for (int i = 0; i < maxChildAmount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            objectIndex--;
            GameObject var = Instantiate(assetList[objectIndex], new Vector3(0, (float)1.15, 0), Quaternion.identity, transform.gameObject.transform);
            var.AddComponent(typeof(Rotation));
            var.AddComponent<Rigidbody>();
            var.GetComponent<Rigidbody>().useGravity = false;
        }
        else if(objectIndex==0)
        {
            for (int i = 0; i < maxChildAmount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            objectIndex = listSize - 1;
            GameObject var = Instantiate(assetList[objectIndex], new Vector3(0, (float)1.15, 0), Quaternion.identity, transform.gameObject.transform);
            var.AddComponent(typeof(Rotation));
            var.AddComponent<Rigidbody>();
            var.GetComponent<Rigidbody>().useGravity = false;
        }
        {
            return;
        }
    }
   
}