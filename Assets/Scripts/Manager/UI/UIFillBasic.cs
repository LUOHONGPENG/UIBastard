using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillBasic : MonoBehaviour
{
    public Image imgFill;
    public Button btnSkill;

    public void Init()
    {
        btnSkill.onClick.RemoveAllListeners();
        btnSkill.onClick.AddListener(delegate ()
        {

        });
    }

    public void SetFill(float fillAmount)
    {
        imgFill.fillAmount = fillAmount;
    }


}
