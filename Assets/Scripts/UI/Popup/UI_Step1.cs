using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Step1 : UI_Popup
{
    enum Buttons
    {
        Sauce1,
        Sauce2,
        Sauce3,
        Cheese
    }

    enum GameObjects
    {
        Blocker1,
        Blocker2,
        SauceBar
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Get<GameObject>((int)GameObjects.Blocker2).gameObject.SetActive(false);
        Get<GameObject>((int)GameObjects.SauceBar).gameObject.SetActive(false);

        //���� customer ���� ������ ��� �̷������� ����
        Get<Button>((int)Buttons.Sauce1).gameObject.BindEvent(OnButtonClicked1);
        Get<Button>((int)Buttons.Sauce2).gameObject.BindEvent(OnButtonClicked2);
        Get<Button>((int)Buttons.Sauce3).gameObject.BindEvent(OnButtonClicked3);
        
    }
    void Start()
    {
        Init();

    }

    void ChangeStep3()
    {
        Managers.uiManagerProperty.ShowPopupUI<UI_Step3>();
    }

    void OnButtonClicked1(PointerEventData data)
    {
        //���ڵ��쿡 �ҽ� �̹����߰�
        Debug.Log("�丶�� �ҽ�");
        //�ҽ� Ŭ��x, ġ�� Ŭ��o, ������ ����
        Get<GameObject>((int)GameObjects.Blocker1).gameObject.SetActive(false);
        Get<GameObject>((int)GameObjects.Blocker2).gameObject.SetActive(true);
        Get<GameObject>((int)GameObjects.SauceBar).gameObject.SetActive(true);

        //ġ�� Ŭ�� + Ŭ���� ���쿡 ġ�� �̹��� �߰�
        Get<Button>((int)Buttons.Cheese).gameObject.BindEvent(OnButtonClicked);
    }

    void OnButtonClicked2(PointerEventData data)
    {
        Debug.Log("������� �ҽ�");
        Get<GameObject>((int)GameObjects.Blocker1).gameObject.SetActive(false);
        Get<GameObject>((int)GameObjects.Blocker2).gameObject.SetActive(true);
        Get<GameObject>((int)GameObjects.SauceBar).gameObject.SetActive(true);

        Get<Button>((int)Buttons.Cheese).gameObject.BindEvent(OnButtonClicked);
    }

    void OnButtonClicked3(PointerEventData data)
    {
        Debug.Log("���� ���� �ҽ�");
        Get<GameObject>((int)GameObjects.Blocker1).gameObject.SetActive(false);
        Get<GameObject>((int)GameObjects.Blocker2).gameObject.SetActive(true);
        Get<GameObject>((int)GameObjects.SauceBar).gameObject.SetActive(true);

        Get<Button>((int)Buttons.Cheese).gameObject.BindEvent(OnButtonClicked);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        //ġ�� �̹��� �ö� �� 0.5�ʵ� �ڵ����� 3�ܰ�� ��ȯ
        Debug.Log("ġ�� �߰�");
        Invoke("ChangeStep3", 0.5f);
    }

    public void OnCloseButtonClicked(PointerEventData data)
    {
        ClosePopupUI();
    }
}
