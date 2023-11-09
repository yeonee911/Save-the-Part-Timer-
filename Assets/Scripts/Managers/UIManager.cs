using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //UI_Popup���� ���� ������ ��
    int m_order = 10;

    //GameObject ���� �������� Popup ������ �ϴ� �� UI_Popup
    Stack<UI_Popup> m_popupStack = new Stack<UI_Popup>();
    UI_Scene m_sceneUI = null;

    public GameObject RootProperty
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null) root = new GameObject { name = "@UI_Root" };
            return root;

        }
    }
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = m_order;
            m_order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Managers.resourceManagerProperty.Instantate($"UI/SubItem/{name}");

        if (parent != null) go.transform.SetParent(parent);
        return Util.GetOrAddComponent<T>(go);
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        //Prefab �̸��� �־����� �ʾҴٸ� Script �̸��� �״�� ������
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Managers.resourceManagerProperty.Instantate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        m_sceneUI = sceneUI;

        go.transform.SetParent(RootProperty.transform);
        return sceneUI;
    }

    //T�� ��ũ��Ʈ �̸�, name �� Prefab �̸� 
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        //Prefab �̸��� �־����� �ʾҴٸ� Script �̸��� �״�� ������
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Managers.resourceManagerProperty.Instantate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        m_popupStack.Push(popup);

        go.transform.SetParent(RootProperty.transform);
        return popup;
    }

    public T ShowPopupUIUnderParent<T>(GameObject parantObject, string name = null) where T : UI_Popup
    {
        //Prefab �̸��� �־����� �ʾҴٸ� Script �̸��� �״�� ������
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Managers.resourceManagerProperty.Instantate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        m_popupStack.Push(popup);

        go.transform.SetParent(parantObject.transform);
        return popup;
    }

    public void SafeClosePopupUIOnTop(UI_Popup popup)
    {
        if (m_popupStack.Count == 0) return;

        if (m_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Faild");
            return;
        }
        ClosePopupUIOnTop();
    }

    public void ClosePopupUIOnTop()
    {
        //Stack ������ Count check �� ��Ȱȭ �� �ʿ� ����
        if (m_popupStack.Count == 0) return;
        UI_Popup popup = m_popupStack.Pop();
        Managers.resourceManagerProperty.Destroy(popup.gameObject);
        popup = null;
    }

    public void CloseAllPopupUI()
    {
        while (m_popupStack.Count > 0)
            ClosePopupUIOnTop();
    }

}
