using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTalk : MonoBehaviour
{
    public GameObject Panel;
    public Text TalkText;
    public GameObject InputName;
    public float delayTime = 3f; //�ϴ� 3�ʷ� 
    float timer = 0f;
    public int index = 0;

    public InputField playerNameInput;
    private string playerName = null;

    private string[] talkData = {
        "1�� ���",
        "2�� ���",
        "3�� ���",
        "4�� ���",
        "5�� ���",
        "6�� ���",
        "7�� ���",
        "8�� ���",
        "",//�̸� �Է�
        "9�� ���"
    };

    private void Awake()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
        TalkText.text = talkData[index];
        index++;
    }

    void Update()
    {
        if(index < 8)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TalkText.text = talkData[index];
                index++;
                timer = 0f;
            }

            else
            {
                timer += Time.deltaTime;
                if (timer >= delayTime)
                {
                    timer = 0f;
                    TalkText.text = talkData[index];
                    index++;
                }
            }
        }

        else if (index == 8)
        {
            InputName.SetActive(true);
            //string str = PlayerPrefs.GetString("Name");
            if (playerName.Length > 0 && Input.GetKeyDown(KeyCode.Return))
            {
                ResultInputName();
                
            }
        }

        else 
        {
            TalkText.text = playerName + ", " + talkData[index];
        }
    }

    public void ResultInputName()
    {
        playerName = playerNameInput.text;
        //PlayerPrefs.SetString("Name", playerName);
        //GameManager.instance. ~~ ���� �޴����� �̸� �Է��ϱ� (���߿�)
        InputName.SetActive(false);
        index++;
    }
}
