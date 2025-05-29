using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SimpleMainMenu : MonoBehaviour
{
    void Start()
    {
        CreateCanvasAndMenu();
    }

    void CreateCanvasAndMenu()
    {
        Debug.Log("Canvas check");
        // Create Canvas
        GameObject canvasGO = new GameObject("MainMenuCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasGO.AddComponent<GraphicRaycaster>();

        // Ensure EventSystem exists
        if (FindFirstObjectByType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }

        // Create an empty GameObject to hold buttons
        GameObject panel = new GameObject("Panel");
        panel.transform.SetParent(canvasGO.transform);

        RectTransform panelRT = panel.AddComponent<RectTransform>();
        panelRT.sizeDelta = new Vector2(400, 400);
        panelRT.anchorMin = new Vector2(0.5f, 0.5f);
        panelRT.anchorMax = new Vector2(0.5f, 0.5f);
        panelRT.pivot = new Vector2(0.5f, 0.5f);
        panelRT.anchoredPosition = Vector2.zero;

        // Add layout group
        VerticalLayoutGroup layout = panel.AddComponent<VerticalLayoutGroup>();
        layout.childAlignment = TextAnchor.MiddleCenter;
        layout.spacing = 15f;
        layout.childForceExpandWidth = false;
        layout.childForceExpandHeight = false;

        ContentSizeFitter fitter = panel.AddComponent<ContentSizeFitter>();
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

        // Create buttons
        CreateButton(panel.transform, "Play Single Player", OnPlaySinglePlayer);
        CreateButton(panel.transform, "Host Server", OnHostServer);
        CreateButton(panel.transform, "Join Server", OnJoinServer);
        CreateButton(panel.transform, "Quit Game", OnQuitGame);
    }

    void CreateButton(Transform parent, string text, UnityEngine.Events.UnityAction action)
    {
        GameObject buttonGO = new GameObject(text + " Button");
        buttonGO.transform.SetParent(parent, false);

        // Add Image and Button
        Image image = buttonGO.AddComponent<Image>();
        image.color = new Color(0.2f, 0.5f, 0.9f);
        Button button = buttonGO.AddComponent<Button>();
        button.targetGraphic = image;
        button.onClick.AddListener(action);

        // RectTransform
        RectTransform rect = buttonGO.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(280, 60);

        // Add Text
        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(buttonGO.transform, false);
        Text label = textGO.AddComponent<Text>();
        label.text = text;
        label.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        label.fontSize = 24;
        label.color = Color.white;
        label.alignment = TextAnchor.MiddleCenter;

        RectTransform textRect = label.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
    }

    // Button Actions
    void OnPlaySinglePlayer() => SceneManager.LoadScene("GameScene");
    void OnHostServer() => Debug.Log("Host Server Clicked");
    void OnJoinServer() => Debug.Log("Join Server Clicked");
    void OnQuitGame()
    {
        Debug.Log("Quit Game Clicked");
        Application.Quit();
    }
}
