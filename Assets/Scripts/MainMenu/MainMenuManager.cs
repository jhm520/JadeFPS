using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        //create a game instance manager if it doesn't exist
        if (GameInstanceManager.Instance == null)
        {
            GameObject gameInstanceGO = new GameObject("GameInstanceManager");
            gameInstanceGO.AddComponent<GameInstanceManager>();
        }
        
        GameInstanceManager.PlayerGameInstanceTagContainer.RemoveTagByName("GameplayTag/JadeFPS/Game/PlaySolo");
        GameInstanceManager.PlayerGameInstanceTagContainer.RemoveTagByName("GameplayTag/JadeFPS/Game/HostServer");

        // Create Canvas
        GameObject canvasGO = new GameObject("MainMenuCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasGO.AddComponent<GraphicRaycaster>();

        // Ensure EventSystem exists
        if (FindFirstObjectByType<EventSystem>() == null)
        {
            GameObject eventSystemGO = new GameObject("EventSystem");
            eventSystemGO.AddComponent<EventSystem>();
            eventSystemGO.AddComponent<StandaloneInputModule>();
        }

        // Create centered rectangle panel
        GameObject panelGO = new GameObject("MainMenuPanel");
        panelGO.transform.SetParent(canvasGO.transform, false);
        Image panelImage = panelGO.AddComponent<Image>();
        panelImage.color = new Color(0.1f, 0.2f, 0.3f, 0.9f); // Dark translucent background

        RectTransform panelRT = panelGO.GetComponent<RectTransform>();
        panelRT.sizeDelta = new Vector2(300, 350);
        panelRT.anchorMin = new Vector2(0.5f, 0.5f);
        panelRT.anchorMax = new Vector2(0.5f, 0.5f);
        panelRT.pivot = new Vector2(0.5f, 0.5f);
        panelRT.anchoredPosition = Vector2.zero;
        
        //create play solo button
            
       CreatePlaySoloButton(panelGO);
       CreateHostServerButton(panelGO);
    }

    void CreateMainMenuButton(GameObject panelGO, string ButtonText, Vector2 anchorMin, Vector2 anchorMax,
        UnityAction buttonCallback)
    {
        // ✅ Create a button in top quarter of panel
        GameObject PlaySoloButtonGO = new GameObject("PlaySoloButton");
        PlaySoloButtonGO.transform.SetParent(panelGO.transform, false);
        
        // Add required components
        Image PlaySoloImage = PlaySoloButtonGO.AddComponent<Image>();
        //set the color of the image
        PlaySoloImage.color = new Color(0.7f, 0.7f, 0.7f, 0.9f);

        
        //set the button's image to the image
        Button PlaySoloButton = PlaySoloButtonGO.AddComponent<Button>();
        PlaySoloButton.targetGraphic = PlaySoloImage;

        // Size and position (top quarter of the panel)
        RectTransform PlaySoloRT = PlaySoloButtonGO.GetComponent<RectTransform>();
        PlaySoloRT.anchorMin = anchorMin;
        PlaySoloRT.anchorMax = anchorMax;
        PlaySoloRT.offsetMin = Vector2.zero;
        PlaySoloRT.offsetMax = Vector2.zero;

        // ✅ Add centered text inside the button
        GameObject PlaySoloTextGO = new GameObject("ButtonText");
        PlaySoloTextGO.transform.SetParent(PlaySoloButtonGO.transform, false);

        Text buttonText = PlaySoloTextGO.AddComponent<Text>();
        buttonText.text = ButtonText;
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.color = Color.black;
        buttonText.fontSize = 24;
        Font NewFont = Resources.Load<Font>("Fonts/OpenSans-Medium");
        buttonText.font = NewFont;

        RectTransform textRT = buttonText.GetComponent<RectTransform>();
        textRT.anchorMin = Vector2.zero;
        textRT.anchorMax = Vector2.one;
        textRT.offsetMin = Vector2.zero;
        textRT.offsetMax = Vector2.zero;
        
        // ✅ Add a click listener
        PlaySoloButton.onClick.AddListener(buttonCallback);
    }

    void CreatePlaySoloButton(GameObject panelGO)
    {
        CreateMainMenuButton(panelGO, "Play Solo", new Vector2(0.1f, 0.75f), new Vector2(0.9f, 0.9f), OnPlaySolo);
    }
    
    void CreateHostServerButton(GameObject panelGO)
    {
        CreateMainMenuButton(panelGO, "Host Server", new Vector2(0.1f, 0.50f), new Vector2(0.9f, 0.65f), OnHostServer);
    }
    
    // Button Callbacks
    void OnPlaySolo()
    {
        GameInstanceManager.PlayerGameInstanceTagContainer.AddTagByName("GameplayTag/JadeFPS/Game/PlaySolo");
        SceneManager.LoadScene("PlayScene");
    }// Replace with your real scene
    
    void OnHostServer()
    {
        GameInstanceManager.PlayerGameInstanceTagContainer.AddTagByName("GameplayTag/JadeFPS/Game/HostServer");
        SceneManager.LoadScene("PlayScene");
    }// Replace with your real scene
    void OnJoinServer() => Debug.Log("Join Server pressed");
    void OnQuitGame()
    {
        Debug.Log("Quit Game pressed");
        Application.Quit();
    }
}