using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBasic : MonoBehaviour
{
    public SpriteRenderer srMonster;

    private float curHP;

    public void Init()
    {
        curHP = 100f;
    }

    public void GetHurt(float damage)
    {
        curHP -= damage;
        //Pass the coordinate of the 3D object
        Vector3 objPos = transform.position;
        GameMgr.Instance.uiMgr.effectUIMgr.InitDamageText(Mathf.Abs(damage), objPos);

        if (curHP <= 0)
        {
            Destroy(this.gameObject);
        }
        TurnRed();
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
