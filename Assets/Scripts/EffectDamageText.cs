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
    private Vector3 offset_start;
    private bool isInit = false;
    private Camera mapCamera;

    public void Init(float info,Vector2 objPos)
    {
        //Text Info
        txDamage.text = ((int)(info)).ToString();

        //Record the coordinate of the 3D Object
        posObject = objPos;

        //Record Original Offset
        mapCamera = GameMgr.Instance.MapCamera;
        offset_start = posObject - mapCamera.transform.position;

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
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(GameMgr.Instance.MapCamera, posObject);
        Vector2 targetPos = new Vector2(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2);
        return new Vector3(targetPos.x, targetPos.y, 0);
    }


    private void Update()
    {
        if (isInit)
        {
            Vector3 offset_current = posObject - mapCamera.transform.position - offset_start;
            transform.localPosition = CalculateUICanvasPos(posObject + offset_current);
            /*            Vector3 offset = (transform.position - MapCamera.transform.position) - posDelta;
                        this.transform.position = this.transform.position - offset;*/
        }
    }

}
