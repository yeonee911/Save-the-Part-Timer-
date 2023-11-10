using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Lobby : UI_Scene
{
    float delayTime = 3f; //�ϴ� 3�ʷ� 
    float timer = 0f;
    int index = 0;
    bool CoroutineRunning = false;

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
        Employee,
        Manager,
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

        Get<GameObject>((int)GameObjects.Employee).SetActive(false);
        Get<GameObject>((int)GameObjects.Manager).SetActive(false);

        Get<Text>((int)Texts.TalkText).text = talkData[index];
        index++;
    }


    void Update()
    {
        if (!CoroutineRunning)
        {
            if (index == 12)
            {
                ShowCharacterImg();
                StartCoroutine(ResultInputNameCoroutine());
            }

            else if (index == 13)
            {
                ShowCharacterImg();
                Get<Text>((int)Texts.TalkText).text = Managers.s_managersProperty.playerNameProperty + talkData[index];
                index++;
            }

            else if (index < talkData.Length)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShowCharacterImg();
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
                        ShowCharacterImg();
                        Get<Text>((int)Texts.TalkText).text = talkData[index];
                        index++;
                    }
                }
            }

            else
            {
                Debug.Log("��ȭ�� ����Ǿ����ϴ�.");
                //SceneManager.LoadScene("Main");
                CoroutineRunning = false;
            }

        }
    }

    IEnumerator ResultInputNameCoroutine()
    {
        CoroutineRunning = true;
        
        if (!Managers.uiManagerProperty.IsPopupOpen<UI_DoInput>())
        {
            if (Managers.s_managersProperty.playerNameProperty == "Guest")
            {
                UI_Popup tmp = Managers.uiManagerProperty.ShowPopupUI<UI_DoInput>();
            }
            else
            {
                UI_Popup tmp = Managers.uiManagerProperty.ShowPopupUI<UI_Welcome>();
            }
            
            yield return new WaitUntil(() => !Managers.uiManagerProperty.IsPopupOpen<UI_DoInput>() &&
                                          !Managers.uiManagerProperty.IsPopupOpen<UI_Welcome>());

        }

        index++;
        CoroutineRunning = false;
    }

    void ShowCharacterImg()
    {
        if (index >= 0 && index <= 5 || index == 8 || index >= 14)
        {
            Get<GameObject>((int)GameObjects.Employee).SetActive(true);
            Get<GameObject>((int)GameObjects.Manager).SetActive(false);
        }
        else if (index == 9 || index == 13)
        {
            Get<GameObject>((int)GameObjects.Employee).SetActive(false);
            Get<GameObject>((int)GameObjects.Manager).SetActive(true);
        }
        else if (index >= 10 && index <= 12)
        {
            Get<GameObject>((int)GameObjects.Employee).SetActive(true);
            Get<GameObject>((int)GameObjects.Manager).SetActive(true);
        }
    }


}