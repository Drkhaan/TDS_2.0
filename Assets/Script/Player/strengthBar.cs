using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class strengthBar : MonoBehaviour
{
    public float actualStrength;

    public float strengthGain;
    public float strengthLoss;
    public RectTransform fill;
    public RectTransform bar;
    public Image fillImg;

    //clamp
    float minFillValue = 0;
    float maxFillValue = 1;

    public bool isStrong = false;

    // Update is called once per frame
    void Update()
    {    

        fill.localScale = new Vector3 ( actualStrength , 0.94999f , 1 );   

        actualStrength = Mathf.Clamp( actualStrength , minFillValue , maxFillValue );


        if ( isStrong == false & actualStrength > 0  )
        {
            strengthLosing();

        } else if ( isStrong == true & actualStrength >= .98f )
        {
            
            StartCoroutine ( "strength");
            
        }
    }

    public void StrengthGain()
    {
        actualStrength += strengthGain;
    }

    void strengthLosing()
    {
        actualStrength -= strengthLoss * Time.deltaTime;

        if ( actualStrength >= .98f )
        {
            isStrong = true;
            StartCoroutine ( "strength" );
        }
    }

    void strengthMax()
    {
        
        Sequence anim = DOTween.Sequence();

        anim.Insert ( 0 , bar.DOScale( 1.1f , .3f ));
        anim.Insert ( 0, fill.DOScale ( 1.1f , .3f ));

        anim.Insert ( .1f , bar.DOScale ( 1 , .3f ));
        anim.Insert ( .1f , fill.DOScale ( 1 , .3f ));

    }

    private IEnumerator strength()
    {

        strengthMax();
        strengthGain = 0;

        //write strength code here 

        yield return new WaitForSeconds ( 2 );

        actualStrength = 0;
        strengthGain = .2f;

        isStrong = false;

        yield return false;

        
    }
}
