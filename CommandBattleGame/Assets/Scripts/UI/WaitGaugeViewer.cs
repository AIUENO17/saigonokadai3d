using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitGaugeViewer : MonoBehaviour
{

    public Image[] CharacterGaugeImages = new Image[3];
    public float[] CharacterSpeeds = new float[3];

    private bool gaugeStop = false;
    // Start is called before the first frame update
   public  void Init()
    {
        for (int i = 0; i < 3; i ++)
        {
            CharacterGaugeImages[i].fillAmount = 0;
        }
    }

    // Update is called once per frame
   public  void WaitGaugeUpDate()
    {
        for (int i = 0; i < 3; i++)
        {
         if (CharacterGaugeImages[i].fillAmount >= 1)
            {
                gaugeStop = true;
            }
         if (gaugeStop)
            {
                return;
            }
            CharacterGaugeImages[i].fillAmount += CharacterSpeeds[i] / 20000f;
        }
    }
    public void ResetWaitGaugeRate(int characterPos)
    {
        CharacterGaugeImages[characterPos].fillAmount = 0;
        gaugeStop = false;
    }



    public float GetWaitGaugeRate(int n)
    {
       return CharacterGaugeImages[n].fillAmount;
    }

    private void LateUpdate()
    {
        WaitGaugeUpDate();
    }
}
