using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    public Transform tfCharacter;
    public SpriteRenderer srCharacter;

    public void TimeFixedGoCharacter(float time)
    {
        TimeFixedGoMove(time);
    }

    private void TimeFixedGoMove(float time)
    {
        float moveRate = time * 1f;

        if(Input.GetAxis("Horizontal") > 0)
        {
            tfCharacter.transform.Translate(Vector3.right * moveRate);
            srCharacter.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            tfCharacter.transform.Translate(Vector3.left * moveRate);
            srCharacter.flipX = false;
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            tfCharacter.transform.Translate(Vector3.forward * moveRate);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            tfCharacter.transform.Translate(Vector3.back * moveRate);
        }
    }
}
