using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Defines.Scene sceneTypeProperty { get; protected set; } = Defines.Scene.Unknown;

    //���⿡ Awake �Լ��� ����� Init �ϸ� Ȯ���� ���� ����
    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null) Managers.resourceManagerProperty.Instantate("UI/EventSystem").name = "@EventSystem";

    }

    public abstract void Clear();
}
