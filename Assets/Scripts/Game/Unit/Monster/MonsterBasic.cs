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

        //Vector3 viewPos = GameMgr.Instance.UICamera.WorldToViewportPoint(transform.position);
        Debug.Log("Pos" + transform.position);
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(GameMgr.Instance.MapCamera, transform.position);
        Vector2 targetPos = new Vector2(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2);

        Debug.Log(targetPos);

        GameMgr.Instance.uiMgr.effectUIMgr.InitDamageText(Mathf.Abs(damage), targetPos);

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
