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
        
        // ✅ Create green rectangle button in top quarter of panel
        GameObject greenButtonGO = new GameObject("TopGreenButton");
        greenButtonGO.transform.SetParent(panelGO.transform, false);

        
        // Add required components
        Image greenImage = greenButtonGO.AddComponent<Image>();
        greenImage.color = Color.green;

        Button greenButton = greenButtonGO.AddComponent<Button>();
        greenButton.targetGraphic = greenImage;

        // Size and position (top quarter of the panel)
        RectTransform greenRT = greenButtonGO.GetComponent<RectTransform>();
        greenRT.anchorMin = new Vector2(0f, 0.75f);
        greenRT.anchorMax = new Vector2(1f, 1f);
        greenRT.offsetMin = Vector2.zero;
        greenRT.offsetMax = Vector2.zero;

        // ✅ Add centered text inside the button
        GameObject textGO = new GameObject("ButtonText");
        textGO.transform.SetParent(greenButtonGO.transform, false);

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
        
        // // ✅ Add green rectangle inside the top quarter of the panel
        // GameObject greenRectGO = new GameObject("TopGreenRectangle");
        // greenRectGO.transform.SetParent(panelGO.transform, false);
        // Image greenImage = greenRectGO.AddComponent<Image>();
        // greenImage.color = Color.green;
        //
        // RectTransform greenRT = greenRectGO.GetComponent<RectTransform>();
        // greenRT.anchorMin = new Vector2(0f, 0.75f); // Bottom-left of top quarter
        // greenRT.anchorMax = new Vector2(1f, 1f);    // Top-right of top quarter
        // greenRT.offsetMin = Vector2.zero;
        // greenRT.offsetMax = Vector2.zero;
        //
        // // ✅ Add centered text inside the green rectangle
        // GameObject textGO = new GameObject("TopText");
        // textGO.transform.SetParent(greenRectGO.transform, false);
        //
        // Text topText = textGO.AddComponent<Text>();
        // topText.text = "Main Menu Title";
        // topText.alignment = TextAnchor.MiddleCenter;
        // topText.color = Color.black;
        // topText.fontSize = 24;
        // Font NewFont = Resources.Load<Font>("Fonts/OpenSans-Medium");
        // topText.font = NewFont;
        //
        // RectTransform textRT = topText.GetComponent<RectTransform>();
        // textRT.anchorMin = Vector2.zero;
        // textRT.anchorMax = Vector2.one;
        // textRT.offsetMin = Vector2.zero;
        // textRT.offsetMax = Vector2.zero;
        
        // // Add layout group for buttons
        // VerticalLayoutGroup layout = panelGO.AddComponent<VerticalLayoutGroup>();
        // layout.childAlignment = TextAnchor.MiddleCenter;
        // layout.spacing = 20f;
        // layout.childForceExpandHeight = false;
        // layout.childForceExpandWidth = true;
        //
        // // Create a Button
        // GameObject buttonGO = new GameObject("TestButton");
        // buttonGO.transform.SetParent(panelGO.transform, false);
        //
        // Button button = buttonGO.AddComponent<Button>();
        // Image buttonImage = buttonGO.AddComponent<Image>();
        // buttonImage.color = new Color(0.25f, 0.6f, 0.9f); // Light blue
        //
        // // Create text for button
        // GameObject textGO = new GameObject("Text");
        // textGO.transform.SetParent(buttonGO.transform, false);
        // Text buttonText = textGO.AddComponent<Text>();
        // buttonText.text = "Click Me!";
        // buttonText.alignment = TextAnchor.MiddleCenter;
        // buttonText.color = Color.white;
        //
        // Font NewFont = Resources.Load<Font>("Fonts/OpenSans-Medium");
        // buttonText.font = NewFont;
        //
        // // Stretch text inside the button
        // RectTransform textRT = buttonText.GetComponent<RectTransform>();
        // textRT.anchorMin = Vector2.zero;
        // textRT.anchorMax = Vector2.one;
        // textRT.offsetMin = Vector2.zero;
        // textRT.offsetMax = Vector2.zero;
        //
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