using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBasic : MonoBehaviour
{
    public void Init(float time,float rotation = 0)
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
        Destroy(this.gameObject, time);
    }
}
