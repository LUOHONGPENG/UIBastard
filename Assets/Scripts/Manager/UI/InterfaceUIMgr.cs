using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUIMgr : MonoBehaviour
{
    public Button btnSetting;
    [Header("CharacterUI")]
    public Button btnCharacter;
    public Transform tfHeart;
    public GameObject pfHeart;
    public Transform tfEnergy;
    public GameObject pfEnergy;
    private CharacterBasic character;
    private List<UIFillBasic> listHeart = new List<UIFillBasic>();
    private List<UIFillBasic> listEnergy = new List<UIFillBasic>();


    private bool isInit = false;

    public void Init()
    {
        character = GameMgr.Instance.levelMgr.character;
        InitCharacterUI();
        isInit = true;
    }

    public void InitCharacterUI()
    {
        CharacterModel characterModel = character.GetCharacterModel();
        //HP
        listHeart.Clear();
        PublicTool.ClearChildItem(tfHeart);
        for (int i = 0; i < characterModel.HPLimit; i++)
        {
            GameObject objHeart = GameObject.Instantiate(pfHeart, tfHeart);
            UIFillBasic itemHeart = objHeart.GetComponent<UIFillBasic>();
            listHeart.Add(itemHeart);
        }
        //EP
        listEnergy.Clear();
        PublicTool.ClearChildItem(tfEnergy);
        for (int i = 0; i < characterModel.EPLimit; i++)
        {
            GameObject objEnergy = GameObject.Instantiate(pfEnergy, tfEnergy);
            UIFillBasic itemEnergy = objEnergy.GetComponent<UIFillBasic>();
            listEnergy.Add(itemEnergy);
        }
    }

    private void Update()
    {
        if (isInit)
        {
            RefreshCurHPEP();
        }
    }

    public void RefreshCurHPEP()
    {
        //HP
        float curHP = character.currentHP;
        for (int i = 0; i < listHeart.Count; i++)
        {
            if (curHP >= i + 1)
            {
                listHeart[i].SetFill(1f);
            }
            else
            {
                listHeart[i].SetFill(curHP - i);
            }
        }
        //EP
        float curEP = character.currentEP;
        for (int i = 0; i < listEnergy.Count; i++)
        {
            if (curEP >= i + 1)
            {
                listEnergy[i].SetFill(1f);
            }
            else
            {
                listEnergy[i].SetFill(curEP - i);
            }
        }
    }
}
