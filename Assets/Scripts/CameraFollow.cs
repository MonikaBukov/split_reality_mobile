using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private float minX = -10f;
    private float maxX = 10f;
    private float minY = -5f;
    private float maxY = 5f;

    void LateUpdate()
    {
        Orientation();
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
  

    void Orientation()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            minX = -7.4f;
            maxX = 7.9f;
            minY = -1.0f;
            maxY = 0.4f;
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            minX = -1.8f;
            maxX = 2.3f;
            minY = -7.7f;
            maxY = 7.4f;

        }
    }
}
