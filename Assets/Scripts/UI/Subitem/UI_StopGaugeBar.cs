using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// isMoving�� ���� ��� �������� minValue�� maxValue���̸� �̵���Ų��.
/// </summary>
public class UI_StopGaugeBar : UI_Base
{
    private Image gaugeBar;

    public bool isMoving = true; //������ �̵� bool��
    public float current = 0; //������ ���簪
    public float minValue = 0; //������ �ּҰ�
    public float maxValue = 100f; //������ �ִ밪
    public float autoMovingValue = 50f; //������ �����̴� �ӵ�

    private int direction = 1;
    enum Images
    {
        Background,
        Gauge
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));
        gaugeBar = Get<Image>((int)Images.Gauge);
        gaugeBar.fillAmount = current / 100;
    }

    void Start()
    {
        Init();
    }
    private void Update()
    {
        if (isMoving)
        {
            GaugeBarUpdate();//test��
        }
        else return;
    }
    private void GaugeBarUpdate()
    {
        gaugeBar.fillAmount = current / 100;
        if (isMoving)
        {
            current = Mathf.Clamp(current + autoMovingValue * direction * Time.deltaTime, minValue, maxValue);
            if (current >= maxValue || current <= minValue)
            {
                direction *= -1; // ���� ����
            }
        }
    }
    /// <summary>
    /// �����̴� �������� ���߰� ���簪 ��ȯ
    /// </summary>
    /// <returns>float UI_StopGaugeBar.current</returns>
    public float GetCurrentGauge()
    {
        isMoving = false;
        return current;
    }

    public void GaugeUp(float value)
    {
        current += value;
    }

    public void GaugeDown(float value)
    {
        current -= value;
    }

}
