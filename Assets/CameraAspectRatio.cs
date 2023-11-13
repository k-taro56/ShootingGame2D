using UnityEngine;

public class CameraAspectAdjuster : MonoBehaviour
{
    Camera cam;
    Vector2 lastScreenSize;

    void Start()
    {
        cam = GetComponent<Camera>();
        lastScreenSize = new Vector2(Screen.width, Screen.height);
        AdjustCamera();
    }

    void Update()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        if (screenSize != lastScreenSize)
        {
            AdjustCamera();
            lastScreenSize = screenSize;
        }
    }

    void AdjustCamera()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        cam.aspect = windowAspect;
    }
}
