using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUIMgr : MonoBehaviour
{
    public Transform tfDamageText;
    public GameObject pfDamageText;

    public void InitDamageText(float damage,Vector3 pos)
    {
        GameObject objDamage = GameObject.Instantiate(pfDamageText, tfDamageText);
        EffectDamageText efDamage = objDamage.GetComponent<EffectDamageText>();
        efDamage.Init(damage, pos);
    }
}
