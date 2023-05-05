using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public GameObject objSkillBlue;
    public InterfaceUIMgr interfaceUIMgr;
    public void Init()
    {
        interfaceUIMgr.Init();
    }

    private void Update()
    {
        if (GameMgr.Instance.isSkillReady)
        {
            objSkillBlue.SetActive(true);
        }
        else
        {
            objSkillBlue.SetActive(false);
        }
    }
}
