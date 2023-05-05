using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterBasic : MonoBehaviour
{
    public Transform tfCharacter;
    public SpriteRenderer srCharacter;

    public void Init()
    {
        InitModel();

        EventCenter.Instance.AddEventListener("NormalAttack", NormalAttackEvent);
        EventCenter.Instance.AddEventListener("SpecialAttack", SpecialAttackEvent);
        EventCenter.Instance.AddEventListener("SkillReady", SkillReadyEvent);
        EventCenter.Instance.AddEventListener("SkillExecute", SkillExecuteEvent);

        stateType = CharacterStateType.Normal;
    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("NormalAttack", NormalAttackEvent);
        EventCenter.Instance.RemoveEventListener("SpecialAttack", SpecialAttackEvent);
        EventCenter.Instance.RemoveEventListener("SkillReady", SkillReadyEvent);
        EventCenter.Instance.RemoveEventListener("SkillExecute", SkillExecuteEvent);
    }


    #region Time

    public void TimeFixedGoCharacter(float time)
    {
        TimeFixedGoMove(time);
        TimeGoRecover(time);
    }
    #endregion

    private void TimeFixedGoMove(float time)
    {
        float moveRate = time * 2f;

        if(GameMgr.Instance.movementVec.x > 0)
        {
            tfCharacter.transform.Translate(Vector3.right * moveRate);
            srCharacter.flipX = true;
        }
        else if (GameMgr.Instance.movementVec.x < 0)
        {
            tfCharacter.transform.Translate(Vector3.left * moveRate);
            srCharacter.flipX = false;
        }

        if(GameMgr.Instance.movementVec.y > 0)
        {
            tfCharacter.transform.Translate(Vector3.forward * moveRate);
        }
        else if(GameMgr.Instance.movementVec.y < 0)
        {
            tfCharacter.transform.Translate(Vector3.back * moveRate);
        }
    }
}
