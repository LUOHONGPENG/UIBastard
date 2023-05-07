using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillTipBasic : MonoBehaviour
{
    public UIHoverBasic hoverBasic;
    public Button btnSkill;

    public void Init(int SkillID)
    {
        btnSkill.onClick.RemoveAllListeners();
        btnSkill.onClick.AddListener(delegate ()
        {
            EventCenter.Instance.EventTrigger("SkillExecute", SkillID);
        });

        if (hoverBasic != null)
        {
            hoverBasic.hoverEnterEvent = delegate ()
            {
                EventCenter.Instance.EventTrigger("ShowSkillTip", SkillID);
            };

            hoverBasic.hoverLeaveEvent = delegate ()
            {
                EventCenter.Instance.EventTrigger("HideSkillTip", null);
            };
        }
    }
}
