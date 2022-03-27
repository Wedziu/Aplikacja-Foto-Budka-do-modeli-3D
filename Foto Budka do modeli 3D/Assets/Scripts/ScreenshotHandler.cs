using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetScreenshotButton()
    {
        StartCoroutine(GetScreenshot());
    }
    
   public IEnumerator GetScreenshot()
    {
        yield return null;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        string folderPath = System.IO.Directory.GetCurrentDirectory() + "/Output";

        if (!System.IO.Directory.Exists(folderPath))
            System.IO.Directory.CreateDirectory(folderPath);

        var screenshotName =
                                "Screenshot_" +
                                System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
                                ".png";
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
    }
}

