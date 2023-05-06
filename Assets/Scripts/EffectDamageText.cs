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

    private Vector3 posObject;
    private bool isInit = false;

    public void Init(float info,Vector3 objPos)
    {
        //Text Info
        txDamage.text = ((int)(info)).ToString();

        //Record the coordinate of the 3D Object
        posObject = objPos;

        //Calculate UI Position
        transform.localPosition = CalculateUICanvasPos(posObject);

        //Animation
        seq = DOTween.Sequence();
        seq.Append(txDamage.transform.DOLocalMoveY(200F, 2F));
        seq.Insert(0.6f, txDamage.DOFade(0, 2f));

        Destroy(gameObject, 3f);
        isInit = true;
    }

    public Vector3 CalculateUICanvasPos(Vector3 objPos)
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(GameMgr.Instance.MapCamera, objPos);
        Vector2 targetPos = new Vector2(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2);
        return new Vector3(targetPos.x, targetPos.y, 0);
    }


    private void Update()
    {
        if (isInit)
        {
            transform.localPosition = CalculateUICanvasPos(posObject);
        }
    }

}
