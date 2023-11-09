using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Lobby : UI_Scene
{
    public float delayTime = 3f; //�ϴ� 3�ʷ� 
    float timer = 0f;
    public int index = 0;
    public bool test = true;

    private string[] talkData = {
        "�����! ���л��̴�!��",
        "���麸�� ����� �����Ȱ ſ�ϱ�, �������� ���� �Ӽ��� ��Ȱ�� ���� �׸���.",
        "�̼��� �Ҿ������ ���Ҵ�.",
        "���� �ܾ� 23,911��",
        "�׷���. ���� ����� ������ �Ǿ��־���.",
        "���� ���� ���� �ں����� ����. ���� ���� �ʹٸ� ���� ����� �ϴ� �Ű�����.   �׷�, �˹�! �˹ٸ� ����!��",
        "���ƽ����� ����� ��� �̱� ��ưڳ׿�.��",
        "������ �˹� ����� ���� ���� �̾��� ���� ã��� ����� ���̾���.",
        "���̹��� ���⳪ �����غ���?�� ������ �Ż������θ� ������ ��ȭ�� ��ǰ���� ���ڰ���.",
        "������ �̹� �ֺ��� ������ �˴ϴ�. ��� �ּ� 3������ ���ؾ� �մϴ�. �����ϰھ��?��",
        "(�� �� ���� �ܾ��� ä��� ���ؼ���� ���� �� ����!) ��, �ס�!",
        "���׷� ���� �ٷΰ�༭���� ���� ������.��",
        "<< �̸��� �Է����ּ��� >>",  //12
        "��? �׷� ������ ���غ��ô�.",   //13
        "���� ������ �� ��Ź�帳�ϴ�!",
        "���� 3������ ��ƿ �� ������?"
    };

    enum GameObjects
    {
        Background,
        Panel,
    }

    enum Buttons
    {
        Clicked
    }

    enum Texts
    {
        TalkText
    }

    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.Clicked).gameObject.BindEvent(OnButtonClicked);
        Get<Text>((int)Texts.TalkText).text = talkData[index];
        index++;
    }
    public void OnButtonClicked(PointerEventData data)
    {

    }

    
    
    void Update()
    {
        
        if(test)
        {
            if (index < 12)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Get<Text>((int)Texts.TalkText).text = talkData[index];
                    index++;
                    timer = 0f;
                }

                else
                {
                    timer += Time.deltaTime;
                    if (timer >= delayTime)
                    {
                        timer = 0f;
                        Get<Text>((int)Texts.TalkText).text = talkData[index];
                        index++;
                    }
                }
            }

            else if (index == 12)
            {
                ResultInputName();
                test = false;
            }

            //update���� ������������ ��� �ؾߵ���, doinput ��� ���� �� �����ϱ�
            /*
            else if (index == 13)
            {
                Get<Text>((int)Texts.TalkText).text = Managers.s_managersProperty.playerNameProperty + ", " + talkData[index];
                index++;
            }

            else
            {
                Get<Text>((int)Texts.TalkText).text = talkData[index];
                index++;
            }*/
        }

        /*
        if (!test)
        {
            if (index == 13)
            {
                Debug.Log("���");
                Get<Text>((int)Texts.TalkText).text = Managers.s_managersProperty.playerNameProperty + ", " + talkData[index];
                index++;
            }

            else if (index == 14)
            {
                Get<Text>((int)Texts.TalkText).text = talkData[index];
                index++;
            }
        }*/

    }

    public void ResultInputName()
    {
        Managers.uiManagerProperty.ShowPopupUI<UI_DoInput>();
        index++;
    }
    
}
