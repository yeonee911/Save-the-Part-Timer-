using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{

    string playerNameKey = "PlayerName";
    string firstGameKey = "IsFirstGame";
    string unlockedRecipesKey = "UnlockedRecipes";
    string availablePizzasKey = "AvailablePizzas";
    string moneyKey = "BankBalance";

    string playerNameProperty { get { return PlayerPrefs.GetString(playerNameKey, "Guest"); } set { PlayerPrefs.SetString(playerNameKey, value); } }
    bool isFirstGameProperty { get { if (PlayerPrefs.GetInt(firstGameKey, 0) == 1) return true; else return false; } set { if (value == true) PlayerPrefs.SetInt(firstGameKey, 1); else PlayerPrefs.SetInt(firstGameKey, 0); } }
    List<string> unlockedRecipesProperty { get { return Util.GetListFromString(PlayerPrefs.GetString(unlockedRecipesKey, "")); } set { PlayerPrefs.SetString(unlockedRecipesKey, Util.GetStringFromList(value)); } }
    List<string> availablePizzasProperty { get { return Util.GetListFromString(PlayerPrefs.GetString(availablePizzasKey, "")); } set { PlayerPrefs.SetString(availablePizzasKey, Util.GetStringFromList(value)); } }
    int moneyProperty { get { return PlayerPrefs.GetInt(moneyKey, 0); } set { PlayerPrefs.SetInt(moneyKey, value); } }

    static Managers s_managers;
    public static Managers s_managersProperty { get { Init(); return s_managers; } }

    InputManager inputManager = new InputManager();
    public static InputManager inputManagerProperty { get { return s_managersProperty.inputManager; } }

    ResourceManager resourceManager = new ResourceManager();
    public static ResourceManager resourceManagerProperty { get { return s_managersProperty.resourceManager; } }

    UIManager uiManager = new UIManager();
    public static UIManager uiManagerProperty { get { return s_managersProperty.uiManager; } }

    SceneManagerEX sceneManager = new SceneManagerEX();
    public static SceneManagerEX sceneManagerEXProperty { get { return s_managersProperty.sceneManager; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.OnUpdate();
    }

    static void Init()
    {
        if (s_managers != null) return;

        GameObject objectManagers = GameObject.Find("@Managers");
        if (objectManagers == null)
        {
            objectManagers = new GameObject { name = "@Managers" };
            objectManagers.AddComponent<Managers>();
        }
        DontDestroyOnLoad(objectManagers);
        s_managers = objectManagers.GetComponent<Managers>(); ;
    }
}
