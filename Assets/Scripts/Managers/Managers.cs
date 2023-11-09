using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Managers : MonoBehaviour
{

    string playerNameKey = "PlayerName";
    string firstGameKey = "IsFirstGame";
    string unlockedRecipesKey = "UnlockedRecipes";
    string availablePizzasKey = "AvailablePizzas";
    string moneyKey = "Money";
    string dDayKey = "DDay";

    [System.Serializable]
    public class PizzaRecipe
    {
        public string name;
        public Steps steps; // Steps�� ���ο� Ŭ������ �˴ϴ�.
    }

    [System.Serializable]
    public class Steps
    {
        public string[] STEP1;
        public string[] STEP2;
        public string[] STEP3;
    }

    [System.Serializable]
    public class PizzaRecipeList
    {
        public PizzaRecipe[] recipes;
        public string[] ReturnStepData(string pizzaName, int step)
        {
            foreach (PizzaRecipe recipe in recipes)
            {
                if (recipe.name == pizzaName)
                {
                    if (step == 0) return recipe.steps.STEP1;
                    else if (step == 1) return recipe.steps.STEP2;
                    else if (step == 2) return recipe.steps.STEP3;
                }
            }
            Debug.Log("���� ��ã��");
            return null;
        }
    }

    public string playerNameProperty { get { return PlayerPrefs.GetString(playerNameKey, "Guest"); } set { PlayerPrefs.SetString(playerNameKey, value); } }
    public bool isFirstGameProperty { get { if (PlayerPrefs.GetInt(firstGameKey, 1) == 1) return true; else return false; } set { if (value == true) PlayerPrefs.SetInt(firstGameKey, 1); else PlayerPrefs.SetInt(firstGameKey, 0); } }
    public List<string> unlockedRecipesProperty { get { return Util.GetListFromString(PlayerPrefs.GetString(unlockedRecipesKey, "")); } set { PlayerPrefs.SetString(unlockedRecipesKey, Util.GetStringFromList(value)); } }
    public List<string> availablePizzasProperty { get { return Util.GetListFromString(PlayerPrefs.GetString(availablePizzasKey, "")); } set { PlayerPrefs.SetString(availablePizzasKey, Util.GetStringFromList(value)); } }
    public int moneyProperty { get { return PlayerPrefs.GetInt(moneyKey, 0); } set { PlayerPrefs.SetInt(moneyKey, value); } }
    //��� �ϼ� �־�� ��
    public int dDayProperty { get { return PlayerPrefs.GetInt(dDayKey, 30); } set { PlayerPrefs.SetInt(dDayKey, value); } }
    
    static public PizzaRecipeList pizzaRecipeList;



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
        LoadPizzaData();
    }

    static void LoadPizzaData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("PizzaRecipe");
        if (jsonFile != null)
        {
            Debug.Log("JSON file loaded successfully.");
            string dataAsJson = jsonFile.text;
            Debug.Log("JSON data: " + dataAsJson);
            pizzaRecipeList = JsonUtility.FromJson<PizzaRecipeList>(dataAsJson);
            if (pizzaRecipeList != null)
            {
                Debug.Log("JSON parsed successfully. Number of recipes: " + pizzaRecipeList.recipes.Length);
            }
            else
            {
                Debug.LogError("Failed to parse JSON data.");
            }
        }
        else
        {
            Debug.LogError("Cannot find json file!");
        }

    }
}
