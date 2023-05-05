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
        transform.position = pos + new Vector2(randomX, randomY);
        //Animation
        seq = DOTween.Sequence();
        seq.Append(txDamage.transform.DOLocalMoveY(200F, 2.5F));
        seq.Insert(0.6f, txDamage.DOFade(0, 2.5f));

        Destroy(gameObject, 3.5f);
    }


    /*    public void Init(float info, DamageTextType type,Vector2 pos)
        {
            if(type== DamageTextType.TimeExtend)
            {
                txDamage.text = string.Format("+{0}s", info);
            }
            else
            {
                txDamage.text = ((int)(info)).ToString();
            }

            switch (type)
            {
                case DamageTextType.EnemyDamage:
                    txDamage.color = listColorDamage[0];
                    outlineDamage.effectColor = listOutlineColor[0];
                    break;
                case DamageTextType.CharacterDamage:
                    txDamage.color = listColorDamage[1];
                    outlineDamage.effectColor = listOutlineColor[1];

                    if (info > 100f)
                    {
                        txDamage.fontSize = 50;
                    }
                    else if(info > 50f)
                    {
                        txDamage.fontSize = 40;
                    }
                    else if(info > 10f)
                    {
                        txDamage.fontSize = 30;
                    }
                    else
                    {
                        txDamage.fontSize = 25;
                    }


                    break;
                case DamageTextType.Heal:
                    txDamage.color = listColorDamage[2];
                    outlineDamage.effectColor = listOutlineColor[2];
                    break;
                case DamageTextType.TimeExtend:
                    txDamage.color = listColorDamage[3];
                    outlineDamage.effectColor = listOutlineColor[3];
                    break;
            }

            float randomX = Random.Range(-0.5f, 0.5f);
            float randomY = Random.Range(-0.5f, 0.5f);
            transform.position = pos + new Vector2(randomX,randomY);

            seq = DOTween.Sequence();
            if (type == DamageTextType.CharacterDamage && info>10f)
            {
                float size = 1.5f;
                if (info > 100f)
                {
                    size = 2.5f;
                }
                else if (info > 50f)
                {
                    size = 2f;
                }

                seq.Append(txDamage.transform.DOScale(size, 0.2f));
                seq.Append(txDamage.transform.DOScale(1f, 0.2f));
                seq.Append(txDamage.transform.DOLocalMoveY(200F, 2.5F));
                seq.Insert(0.6f, txDamage.DOFade(0, 2.5f));
            }
            else
            {
                seq.Append(txDamage.transform.DOLocalMoveY(200F, 2.5F));
                seq.Insert(0.6f, txDamage.DOFade(0, 2.5f));
            }


            Destroy(gameObject, 3.5f);
        }*/
}
