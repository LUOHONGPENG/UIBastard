using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    public CharacterBasic character;
    public Transform tfMonster;
    public GameObject pfMonster;

    public void Init()
    {
        character.Init();

        GenerateTenMon();
    }

    public void GenerateTenMon()
    {
        for(int i = 0; i < 10; i++)
        {
            float posX = Random.Range(-3f, 3f);
            float posZ = Random.Range(-3f, 3f);
            GameObject objMonster = GameObject.Instantiate(pfMonster,new Vector3(posX,1F,posZ),Quaternion.identity,tfMonster);
            MonsterBasic itemMonster = objMonster.GetComponent<MonsterBasic>();
            itemMonster.Init();
        }
    }

    public void TimeFixedGoLevel(float time)
    {
        if (character != null)
        {
            character.TimeFixedGoCharacter(time);
        }
    }
}
