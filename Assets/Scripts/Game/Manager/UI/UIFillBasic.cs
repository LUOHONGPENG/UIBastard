using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillBasic : MonoBehaviour
{
    public Image imgFill;

    public void Init(int skillID)
    {

    }

    public void SetFill(float fillAmount)
    {
        imgFill.fillAmount = fillAmount;
    }


}
