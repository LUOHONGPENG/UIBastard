using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    public CharacterBasic character;

    public void TimeFixedGoLevel(float time)
    {
        if (character != null)
        {
            character.TimeFixedGoCharacter(time);
        }
    }
}
