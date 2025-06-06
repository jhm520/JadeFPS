using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CenteredRectangleUI : MonoBehaviour
{
    void Start()
    {
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
        
        // ✅ Create a button in top quarter of panel
        GameObject ButtonGO = new GameObject("TopGreenButton");
        ButtonGO.transform.SetParent(panelGO.transform, false);

        
        // Add required components
        Image greenImage = ButtonGO.AddComponent<Image>();
        //set the color of the image
        greenImage.color = new Color(0.7f, 0.7f, 0.7f, 0.9f);

        
        //set the button's image to the image
        Button greenButton = ButtonGO.AddComponent<Button>();
        greenButton.targetGraphic = greenImage;

        // Size and position (top quarter of the panel)
        RectTransform greenRT = ButtonGO.GetComponent<RectTransform>();
        greenRT.anchorMin = new Vector2(0.1f, 0.75f);
        greenRT.anchorMax = new Vector2(0.9f, 0.9f);
        greenRT.offsetMin = Vector2.zero;
        greenRT.offsetMax = Vector2.zero;

        // ✅ Add centered text inside the button
        GameObject textGO = new GameObject("ButtonText");
        textGO.transform.SetParent(ButtonGO.transform, false);

        Text buttonText = textGO.AddComponent<Text>();
        buttonText.text = "Main Menu Title";
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
        greenButton.onClick.AddListener(() => Debug.Log("Top green button clicked!"));
    }
    
    // Button Callbacks
    void OnPlaySinglePlayer() => SceneManager.LoadScene("GameScene"); // Replace with your real scene
    void OnHostServer() => Debug.Log("Host Server pressed");
    void OnJoinServer() => Debug.Log("Join Server pressed");
    void OnQuitGame()
    {
        Debug.Log("Quit Game pressed");
        Application.Quit();
    }
}