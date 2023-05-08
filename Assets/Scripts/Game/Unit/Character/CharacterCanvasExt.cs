using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class CharacterBasic
{
    [Header("Canvas")]
    public Image imgIcon;
    public List<Sprite> listSpIcon = new List<Sprite>();


    public void ShowSkillTip(object arg0)
    {
        if(stateType == CharacterStateType.SkillReady)
        {
            imgIcon.gameObject.SetActive(true);
            switch ((int)arg0)
            {
                case 1001:
                    imgIcon.sprite = listSpIcon[0];
                    break;
                case 1002:
                    imgIcon.sprite = listSpIcon[1];
                    break;
                default:
                    imgIcon.sprite = listSpIcon[0];
                    break;
            }
        }
    }

    public void HideSkillTip(object arg0)
    {
        imgIcon.gameObject.SetActive(false);
    }
}
