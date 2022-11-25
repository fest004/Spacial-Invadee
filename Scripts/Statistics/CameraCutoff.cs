using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutoff : MonoBehaviour
{

    public Transform followPosition;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthSize;
    private float cameraRatio;
    private Camera mainCam;




    // Start is called before the first frame update
    void Start()
    {
       xMin = mapBounds.bounds.min.x;
       xMax= mapBounds.bounds.max.x;
       yMin = mapBounds.bounds.min.y;
       yMax= mapBounds.bounds.max.y;
       mainCam = GetComponent<Camera>();
       camOrthSize = mainCam.orthographicSize;
       cameraRatio = (xMax + camOrthSize) / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       camY = Mathf.Clamp(followPosition.position.y, yMin + camOrthSize, yMax - camOrthSize);
       camX = Mathf.Clamp(followPosition.position.x, xMin + camOrthSize, xMax - camOrthSize);
       this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
