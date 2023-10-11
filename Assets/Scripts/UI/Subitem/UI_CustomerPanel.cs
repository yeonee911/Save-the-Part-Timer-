using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CustomerPanel : UI_Base
{
    GameObject[] customers;
    
    public override void Init()
    {
        customers = new GameObject[4];

        foreach (Transform child in transform)
            Managers.resourceManagerProperty.Destroy(child.gameObject);

        for (int i = 0; i < 4; i++)
        {
            GameObject pizzaIndex = Managers.uiManagerProperty.MakeSubItem<UI_Customer>(transform).gameObject;
            pizzaIndex.GetComponent<RectTransform>().localScale = Vector3.one;
            pizzaIndex.SetActive(false);
            pizzaIndex.name = $"CustomerInfo{i}";
            customers[i] = pizzaIndex;
        }

        StartCoroutine(CustomerTest());
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    IEnumerator CustomerTest()
    {
        while(true)
        {
            MakeOrder();
            yield return new WaitForSeconds(2f);
        }
    }
    void MakeOrder(float[] raito = null, int deadLine = 10)
    {
        float randomNumber = Random.Range(0f, 100f);
        GameObject firstEmpty = null;

        if (raito == null) raito = new float[] { 15, 30, 45, 60, 70, 80, 90, 95, 100 };

        for (int i = 0; i < 4; i++)
        {
            if (customers[i].activeSelf == false)
            {
                firstEmpty = customers[i];
            }
        }

        if (firstEmpty == null)
        {
            Debug.Log("CustomerFull");
            return;
        }

        firstEmpty.GetComponent<UI_Customer>().timeLeft = deadLine;
        firstEmpty.GetComponent<UI_Customer>().deadLine = deadLine;

        if (randomNumber < raito[0])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "ġ�� ����";
        }
        else if (randomNumber < raito[1])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "���۷δ� ����";
        }
        else if (randomNumber < raito[2])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "�������������� ����";
        }
        else if (randomNumber < raito[3])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "�Ұ�� ����";
        }
        else if (randomNumber < raito[4])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "������ ����";
        }
        else if (randomNumber < raito[5])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "�޺���̼� ����";
        }
        else if (randomNumber < raito[6])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "���۷δ�&�������� �ݹ� ����";
        }
        else if (randomNumber < raito[7])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "�Ұ��&������ �ݹ� ����";
        }
        else if (randomNumber < raito[8])
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "��������&�Ұ�� �ݹ� ����";
        }
        else
        {
            firstEmpty.GetComponent<UI_Customer>().orderName = "??? ����";
        }
        firstEmpty.SetActive(true);
        firstEmpty.transform.SetAsFirstSibling();
    }
}
