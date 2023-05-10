using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static bool t_conditionRespawn = false;

    Transform target;

    [SerializeField]
    private float smoothSpeed = 0.1f;
    private int counterWait = 0;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CameraControll();
    }

    public void ResetCamera()
    {
        t_conditionRespawn = true;
    }

    void CameraControll()
    {
        if (!t_conditionRespawn)
        {
            Vector3 startPosition = new Vector3(target.position.x, target.position.y, -10f);
            Vector3 smoothCamera = Vector3.Lerp(transform.position, startPosition, smoothSpeed);

            if (transform.position.y <= target.position.y)
            {
                transform.position = smoothCamera;
            }
            else
            {
                Vector3 waitPosition = new Vector3(target.position.x, transform.position.y, -10f);
                Vector3 smoothCameraWait = Vector3.Lerp(transform.position, waitPosition, smoothSpeed);

                transform.position = smoothCameraWait;
            }
        }
        else
        {
            Vector3 startPosition = new Vector3(target.position.x, target.position.y, -10f);
            Vector3 smoothCamera = Vector3.Lerp(transform.position, startPosition, smoothSpeed);

            transform.position = smoothCamera;

            if (counterWait < 35)
            {
                counterWait++;
            }
            else
            {
                t_conditionRespawn = false;
                counterWait = 0;
            }
            
        }
    }
}
