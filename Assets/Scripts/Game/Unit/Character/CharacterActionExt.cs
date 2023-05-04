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
        Vector2 vecGround = new Vector2(groundPos.x - tfCharacter.position.x, groundPos.z - tfCharacter.position.z);
        float angleGround = PublicTool.CalculateAngle(vecGround, new Vector2(0, 1));
        //View
        GameObject objEffect = GameObject.Instantiate((GameObject)Resources.Load("Effect/EffectSlap"), tfEffect);
        EffectBasic itemEffect = objEffect.GetComponent<EffectBasic>();
        itemEffect.Init(0.5f, angleGround);

        //DetectMonster
        Collider[] hits = Physics.OverlapSphere(tfCharacter.position, 0.5f);
        foreach (var hit in hits)
        {
            Vector2 vecMon = new Vector2(hit.transform.position.x - tfCharacter.position.x, hit.transform.position.z - tfCharacter.position.z);
            float angleMon = PublicTool.CalculateAngle(vecMon, vecGround);
            if (Mathf.Abs(angleMon) > 90f)
            {
                continue;
            }

            if (hit.tag == "Monster")
            {
                MonsterBasic mon = hit.GetComponent<MonsterBasic>();
                if(mon != null)
                {
                    mon.TurnRed();
                }
            }
        }
    }

    private void SkillReadyEvent(object arg0)
    {

    }

    private void SpecialAttackEvent(object arg0)
    {

    }
}
