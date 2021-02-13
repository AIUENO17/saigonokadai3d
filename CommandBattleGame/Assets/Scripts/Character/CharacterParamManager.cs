using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParamManager : MonoBehaviour
{
    public CharacterParam CharacterParam = new CharacterParam();





    public string CharacterName = string.Empty;
        
        
   public int CharacterHP = 0;
    public int CharacterMp = 0;
    public float CharacterSpeed = 0;
    public int CharacterAttack = 0;
    public CharacterParam.GameCharacterType CharacterType = CharacterParam.GameCharacterType.Invalide;

    public CharacterAnimationController CharacterAnimationController = null;
    public bool IsEnemy = false;
    private float attackSpan;
    // Start is called before the first frame update
    private void Init()
    {
        CharacterParam.Name = CharacterName;
        CharacterParam.HitPoint = CharacterHP;

        CharacterParam.MagicPoint = CharacterMp;

        CharacterParam.Speed = CharacterSpeed;

        CharacterParam.CharacterType = CharacterType;

        CharacterParam.Attack = CharacterAttack;

        CharacterParam.IsEnemy = IsEnemy;

        if (!IsEnemy)
        {
            CharacterParam.FirstButtonAction = FirstButtonAction;
            CharacterParam.SecondButtonAction = SecondButtonAction;
            CharacterParam.ThirdButtonAction = ThirdButtonAction;
            CharacterParam.FourthButtonAction = FourthButtonAction;

        }
        else
        {
            attackSpan = 10f;
        }
        CharacterAnimationController = this.gameObject.GetComponent<CharacterAnimationController>();
    }
    private void Update()
    {

        if (IsEnemy)
        {
            attackSpan -= Time.deltaTime;
            if (attackSpan < 0)
                StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

            attackSpan = 10f;
        }
    }
    

    // Update is called once per frame
    private void Awake()
    {
        Init();
    }



    //一番目のボタンを押して行動出来たらaaと表示（確認の時に使う）
    private void FirstButtonAction()
    {

        StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

        ButtonNo = 0;

    }
    private void SecondButtonAction()
    {
        ButtonNo = 1;

        Debug.Log("bb");


        if (CharacterType == CharacterParam.GameCharacterType.SpellCaster)
        {



            StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

        }
    }
    private void ThirdButtonAction()
    {
        Debug.Log("cc");

        StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

        ButtonNo = 3;
    }

    private void FourthButtonAction()
    {
        Debug.Log("dd");
    }

    public CharacterHpViewer m_CharacterHpViewer = null;

    public void Damage(int damage)
    {
        var characterPos = m_CharacterHpViewer;

        CharacterParam.HitPoint -= damage;

        CharacterHP = CharacterParam.HitPoint;

        if (!IsEnemy)
        {
            // 回復でかつ、最大値を越えてしまった場合
            if (damage < 0 &&
                characterHpViewer.CharacterMaxHps[characterPos] < CharacterHP)
            {
                CharacterHP = characterHpViewer.CharacterMaxHps[characterPos];
                CharacterParam.HitPoint = CharacterHP;
            }
            characterHpViewer.SetHp(characterPos, CharacterHP);
        }
    }
}

    

