using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterBasic
{
    public Transform tfEffect;
    public CharacterStateType stateType;

    private void Heal(float healPoint)
    {
        currentHP += healPoint;
        if(currentHP>= HPLimit)
        {
            currentHP = HPLimit;
        }
    }

    public void NormalAttackEvent(object arg0)
    {
        if(stateType == CharacterStateType.Normal)
        {
            //CalculateAngle
            Vector3 groundPos = (Vector3)arg0;
            Vector2 vecGround = new Vector2(groundPos.x - tfCharacter.position.x, groundPos.z - tfCharacter.position.z);
            float angleGround = PublicTool.CalculateAngle(vecGround, new Vector2(0, 1));
            //View
            GameObject objEffect = GameObject.Instantiate((GameObject)Resources.Load("Effect/EffectSlap"), tfEffect);
            EffectBasic itemEffect = objEffect.GetComponent<EffectBasic>();
            itemEffect.Init(0.4f, angleGround);

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
                    if (mon != null)
                    {
                        mon.GetHurt(50f);
                    }
                }
            }
        }
        else if(stateType == CharacterStateType.SkillRange)
        {



        }
    }
    private void SpecialAttackEvent(object arg0)
    {
        if (stateType == CharacterStateType.Normal)
        {
            //View
            GameObject objEffect = GameObject.Instantiate((GameObject)Resources.Load("Effect/EffectInsult"), tfEffect);
            EffectBasic itemEffect = objEffect.GetComponent<EffectBasic>();
            itemEffect.Init(0.4f);
            //DetectMonster
            Collider[] hits = Physics.OverlapSphere(tfCharacter.position, 1f);
            foreach (var hit in hits)
            {
                if (hit.tag == "Monster")
                {
                    MonsterBasic mon = hit.GetComponent<MonsterBasic>();
                    if (mon != null)
                    {
                        mon.GetHurt(10f);
                    }
                }
            }
        }
    }

    private void SkillReadyEvent(object arg0)
    {
        if(stateType == CharacterStateType.SkillReady || stateType == CharacterStateType.SkillRange)
        {
            SkillOff();
        }
        else if(stateType == CharacterStateType.Normal)
        {
            SkillOn();
        }
    }

    private void SkillOn()
    {
        stateType = CharacterStateType.SkillReady;
        GameMgr.Instance.isSkillReady = true;
    }

    private void SkillOff()
    {
        stateType = CharacterStateType.Normal;
        GameMgr.Instance.isSkillReady = false;
    }


    private void SkillExecuteEvent(object arg0)
    {
        int skillID = (int)arg0;

        switch (skillID)
        {
            case 1001:
                ExecuteSkill1001();
                break;
            case 1002:
                ExecuteSkill1002();
                break;
        }
    }

    private void ExecuteSkill1001()
    {
        if (currentEP >= 2)
        {
            currentEP -= 2f;
            Heal(3f);
            SkillOff();
        }
    }

    private void ExecuteSkill1002()
    {
        if (currentEP >= 2)
        {
            currentEP -= 2f;
/*            //View
            GameObject objEffect = GameObject.Instantiate((GameObject)Resources.Load("Effect/EffectInsult"), tfEffect);
            EffectBasic itemEffect = objEffect.GetComponent<EffectBasic>();
            itemEffect.Init(0.4f);*/
            //DetectMonster
            Collider[] hits = Physics.OverlapSphere(tfCharacter.position,3f);
            foreach (var hit in hits)
            {
                if (hit.tag == "Monster")
                {
                    MonsterBasic mon = hit.GetComponent<MonsterBasic>();
                    if (mon != null)
                    {
                        mon.GetHurt(40f);
                    }
                }
            }
            SkillOff();
        }
    }
}
