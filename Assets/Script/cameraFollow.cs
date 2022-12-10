using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 origin;
    private Vector3 Different;
    private bool drag = false;

    public float ZoomChange;
    public float SmoothChange;
    public float MinSize, MaxSize;
    private Camera _cam;

    private Vector3 oldPosition;

    public static cameraFollow _camera;
   

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        _camera = this;
        oldPosition = this.transform.position;
    }
    // Update is called once per frame
   


    public void resetPosition()
    {

        this.transform.position = oldPosition;


    }

   public void moveCamera()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _cam.orthographicSize -= ZoomChange * Time.deltaTime * SmoothChange;


        }
        if (Input.mouseScrollDelta.y < 0)
        {
            _cam.orthographicSize += ZoomChange * Time.deltaTime * SmoothChange;

        }

        _cam.orthographicSize = Mathf.Clamp(_cam.orthographicSize, MinSize, MaxSize);

        if (Input.GetMouseButton(0))
        {


            Different = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {

                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            }
        }
        else
        {

            drag = false;

        }

        if (drag)
        {

            Camera.main.transform.position = origin - Different;

        }
    }
}
