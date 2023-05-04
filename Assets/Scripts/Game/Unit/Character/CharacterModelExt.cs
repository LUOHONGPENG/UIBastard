
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterBasic
{
    private CharacterModel characterModel;

    public float currentHP;
    public float currentEP;

    #region GetData
    public CharacterModel GetCharacterModel()
    {
        if (characterModel != null)
        {
            return characterModel;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// The max limit of HP
    /// </summary>
    public int HPLimit
    {
        get
        {
            if (characterModel != null)
            {
                return characterModel.HPLimit;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// The max limit of EP
    /// </summary>
    public int EPLimit
    {
        get
        {
            if (characterModel != null)
            {
                return characterModel.EPLimit;
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion

    public void InitModel()
    {
        characterModel = GameMgr.Instance.dataMgr.characterModel;
        currentHP = HPLimit;
        currentEP = 0;
    }

    public void TimeGoRecover(float time)
    {
        if(currentEP < EPLimit)
        {
            currentEP += time * 0.25f;
        }
    }
}
