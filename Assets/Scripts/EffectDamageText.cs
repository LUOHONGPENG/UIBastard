using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EffectDamageText : MonoBehaviour
{
    public Text txDamage;
    public Outline outlineDamage;
    public List<Color> listColorDamage = new List<Color>();
    public List<Color> listOutlineColor = new List<Color>();
    private Sequence seq;

    public void Init(float info,Vector2 pos)
    {
        //Text Info
        txDamage.text = ((int)(info)).ToString();
        //RandomPos
        float randomX = Random.Range(-0.5f, 0.5f);
        float randomY = Random.Range(-0.5f, 0.5f);
        transform.localPosition = new Vector3(pos.x + randomX, pos.y + randomY, 0);

        //transform.position = new Vector3(pos.x + randomX, pos.y + randomY,0);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        //Animation
        seq = DOTween.Sequence();
        seq.Append(txDamage.transform.DOLocalMoveY(200F, 2.5F));
        seq.Insert(0.6f, txDamage.DOFade(0, 2.5f));

        Destroy(gameObject, 3.5f);
    }

}
