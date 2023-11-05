using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    //�ڼ� GameObject �� ��ȯ
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null) return null;
        else return transform.gameObject;
    }

    //�ڼ� GameObject �� Component �� ��ȯ
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null) return null;
        if (recursive == false)
        {
            //���� �ڽĸ�
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null) return component;
                }
            }
        }
        else
        {
            //��� �ڽĵ�
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name) return component;
            }
        }
        return null;
    }

    public static string GetStringFromList(List<string> stringList)
    {
        return string.Join(";", stringList.ToArray());
    }

    public static List<string> GetListFromString(string key)
    {
        string combinedString = PlayerPrefs.GetString(key);
        return new List<string>(combinedString.Split(';'));
    }
}
