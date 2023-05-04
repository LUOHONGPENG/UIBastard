using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    Vector3 off;
    public float speed = 1f;
    Vector3 ve;
    Quaternion angel;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    private bool isInit = false;

    public void Init(Transform target)
    {
        followTarget = target;
        offsetX = this.transform.position.x - target.position.x;
        offsetY = this.transform.position.y - target.position.y;
        offsetZ = this.transform.position.z - target.position.z;
        isInit = true;
    }


    private void LateUpdate()
    {
        if (!isInit)
        {
            return;
        }
        off = followTarget.position + new Vector3(offsetX, offsetY, offsetZ);
        //off = followTarget.position + height * followTarget.up - forward * followTarget.forward;
        transform.position = Vector3.SmoothDamp(transform.position, off, ref ve, 0);//Using reference to submit variable
/*        angel = Quaternion.LookRotation(followTarget.position - off);
        transform.rotation = Quaternion.Slerp(transform.rotation, angel, Time.deltaTime);*/
    }

}
