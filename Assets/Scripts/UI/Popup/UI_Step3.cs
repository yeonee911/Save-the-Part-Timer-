using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class UI_Step3 : UI_Popup
{
    enum Buttons
    {
        Ingredient1,
        Ingredient2,
        Ingredient3,
        Ingredient4,
        Ingredient5,
        Ingredient6,
        Ingredient7,
        Ingredient8,
        Ingredient9
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        //9�� �� ���� �����ؾߵǴ��� �����Ǿ��ִ��� ���� �ϴ� �̷������� ����
        Get<Button>((int)Buttons.Ingredient1).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient2).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient3).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient4).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient5).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient6).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient7).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient8).gameObject.BindEvent(OnButtonClicked);
        Get<Button>((int)Buttons.Ingredient9).gameObject.BindEvent(OnButtonClicked);
    }
    void Start()
    {
        Init();

    }

    void OnButtonClicked(PointerEventData data)
    {
        //�ش� customer�� �����Ǿ�ߵ�

        ClosePopupUI();
    }

    public void OnCloseButtonClicked(PointerEventData data)
    {
        ClosePopupUI();
    }
}
