using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBasic : MonoBehaviour
{
    public SpriteRenderer srMonster;

    private float curHP;

    public void Init()
    {

    }

    public void TurnRed()
    {
        StopCoroutine(IE_TurnRed());
        StartCoroutine(IE_TurnRed());
    }

    public IEnumerator IE_TurnRed()
    {
        srMonster.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        srMonster.color = Color.white;
    }

}
