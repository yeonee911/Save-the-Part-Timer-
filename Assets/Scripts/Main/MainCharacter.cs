using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    public Text ScriptTxt;
    private int RandomInt;
    private string script;

    void Start()
    {
        ScriptTxt.text = "�⺻ ���";
    }

    public void CharacterText()
    {
        ScriptTxt.text = RandomScript();
    }

    
    public string RandomScript()
    {
        RandomInt = Random.Range(0, 6);

        if (RandomInt == 0)
            script = "1�� ���";
        else if (RandomInt == 1)
            script = "2�� ���";
        else if (RandomInt == 2)
            script = "3�� ���";
        else if (RandomInt == 3)
            script = "4�� ���";
        else if (RandomInt == 4)
            script = "5�� ���";
        else if (RandomInt == 5)
            script = "6�� ���";

        return script;
    }
}
