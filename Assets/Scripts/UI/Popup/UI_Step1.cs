using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;


public class UI_Step1 : UI_Popup
{
    enum Buttons
    {
        TomatoSauce,
        MayonnaiseSauce,
        OnionSauce,
        Cheese,
    }

    public enum GameObjects
    {
        CheeseBlocker,
        SauceBlocker,
        TableBlocker,
        SauceBar
    }

    public bool isSauceSelectDone;
    public bool isCheeseSelcetDone;

    public bool[] chosenSauce;
    
    UI_Game ui_game;

    public override void Init()
    {
        base.Init();

        isSauceSelectDone = false;
        isCheeseSelcetDone = false;

        chosenSauce = new bool[3];
        chosenSauce[0] = false;
        chosenSauce[1] = false;
        chosenSauce[2] = false;

        ui_game = transform.parent.gameObject.GetComponent<UI_Game>();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Get<GameObject>((int)GameObjects.SauceBlocker).SetActive(false);
        Get<Button>((int)Buttons.Cheese).gameObject.BindEvent(OnCheeseClicked);

        Get<Button>((int)Buttons.TomatoSauce).gameObject.BindEvent(OnTomatoClicked);
        Get<Button>((int)Buttons.MayonnaiseSauce).gameObject.BindEvent(OnMayonnaiseClicked);
        Get<Button>((int)Buttons.OnionSauce).gameObject.BindEvent(OnOnionClicked);

    }
    
    void Start()
    {
        Init();

    }

    void ChangeStep3()
    {
        Managers.uiManagerProperty.ShowPopupUIUnderParent<UI_Step3>(transform.parent.gameObject);
    }

    void OnTomatoClicked(PointerEventData data)
    {
        //���ڵ��쿡 �ҽ� �̹����߰�
        Debug.Log("�丶�� �ҽ�");
        //�ҽ� Ŭ��x, ġ�� Ŭ��o, ������ ����
        ChooseSauceAndCheck(0);
    }

    void OnMayonnaiseClicked(PointerEventData data)
    {
        Debug.Log("������� �ҽ�");
        ChooseSauceAndCheck(1);
    }

    void OnOnionClicked(PointerEventData data)
    {
        Debug.Log("���� ���� �ҽ�");
        ChooseSauceAndCheck(2);
    }

    void ChooseSauceAndCheck(int index)
    {
        if (chosenSauce[index] == false) chosenSauce[index] = true;
        else chosenSauce[index] = false;

        if (chosenSauce.SequenceEqual<bool>(ui_game.sauceAnswer))
        {
            Debug.Log("�ҽ� ����");
            isSauceSelectDone = true;
            Get<GameObject>((int)GameObjects.SauceBlocker).SetActive(true);
            Get<GameObject>((int)GameObjects.CheeseBlocker).SetActive(false);
        }

    }
    public void OnCheeseClicked(PointerEventData data)
    {
        //ġ�� �̹��� �ö� �� 0.5�ʵ� �ڵ����� 3�ܰ�� ��ȯ
        Debug.Log("ġ�� �߰�");
        isCheeseSelcetDone = true;
        Invoke("ChangeStep3", 0.5f);
    }
}
