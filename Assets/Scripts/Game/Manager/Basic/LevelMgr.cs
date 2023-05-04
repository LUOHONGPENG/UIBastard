using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    public CharacterBasic character;
    public Transform tfMonster;

    public void Init()
    {
        character.Init();
    }


    public void TimeFixedGoLevel(float time)
    {
        if (character != null)
        {
            character.TimeFixedGoCharacter(time);
        }
    }

    public void TimeGoLevel(float time)
    {
        if(character != null)
        {
            character.TimeGoCharacter(time);
        }
    }
}
