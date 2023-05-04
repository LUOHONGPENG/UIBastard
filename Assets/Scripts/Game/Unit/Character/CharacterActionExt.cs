using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterBasic
{
    public Transform tfEffect;

    public void NormalAttackEvent(object arg0)
    {
        //CalculateAngle
        Vector3 groundPos = (Vector3)arg0;
        Vector2 vecPoint = new Vector2(groundPos.x - tfCharacter.position.x, groundPos.z - tfCharacter.position.z);
        float angle = PublicTool.CalculateAngle(vecPoint, new Vector2(0, 1));
        //DetectMonster


        //View
        GameObject objEffect = GameObject.Instantiate((GameObject)Resources.Load("Effect/EffectSlap"), tfEffect);
        EffectBasic itemEffect = objEffect.GetComponent<EffectBasic>();
        itemEffect.Init(0.5f, angle);
    }

    private void SkillReadyEvent(object arg0)
    {

    }

    private void SpecialAttackEvent(object arg0)
    {

    }
}
