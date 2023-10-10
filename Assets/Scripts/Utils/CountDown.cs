using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ī��Ʈ �ٿ� ������Ʈ : 
/// time �� ī��Ʈ�� �� �Է�
/// ī��Ʈ �ٿ��� ����Ǹ� isCouning�� false�� �ȴ�
/// </summary>
public class CountDown : MonoBehaviour
{
    public Text _timerText;
    public float time = 10f;
    public bool isCounting;
    void Start()
    {
        _timerText = gameObject.GetComponent<Text>();
        StartCoroutine(Timer(time));
    }

    private IEnumerator Timer(float _time)
    {
        isCounting = true;
        while (_time > 0 && isCounting)
        {
            _time -= Time.deltaTime;
            string minutes = Mathf.Floor(_time / 60).ToString("00");
            string seconds = (_time % 60).ToString("00");
            _timerText.text = string.Format("{0}:{1}", minutes, seconds);
            yield return null;

            if (_time <= 0)
            {
                isCounting = false;
                _timerText.text = "Times Up";
            }
        }
    }
    void Update()
    {
        
    }
}
