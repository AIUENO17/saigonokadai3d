using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParamUIPresenter : MonoBehaviour
{
    public CharacterHpViewer CharacterHpViewer = null;
    public CharacterMpViewer CharacterMpViewer = null;
    public WaitGaugeViewer WaitGaugeViewer = null;

    public CenterUIViewer CenterUIViewer = null;
    //CenterUIViwerを宣言
   

    public CharacterNameViewer CenterUIViewew = null;
    public void SetCharacterParamViewer(CharacterParam[] CharacterParams)
    {
        for (int i = 0; i < 3; i++)
        {
            if (CharacterParams[i] != null)
            {
                CharacterHpViewer.CharacterMaxHps[i] = CharacterParams[i].HitPoint;
                CharacterHpViewer.CharacterHps[i] = CharacterParams[i].HitPoint;
                CharacterMpViewer.CharacterMaxMps[i] = CharacterParams.MagicPoint;
                CharacterMpViewer.CharacterMps[i] = CharacterParams[i].MagicPoint;
                WaitGaugeViewer.CharacterSpeeds[i] = CharacterParams[i].Speed;
                CharacterNameViewer.SetNameText(i, CharacterParams[i].Name);
            }
        }
        WaitGaugeViewer.Init();
    }
}
  
