
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Main Panels")]
    public GameObject homePanel;
    public GameObject learningPanel;
    public GameObject earthLayerPanel;
    public GameObject quizPanel;

    [Header("Other Panels")]
    public GameObject earthInfoPanel;

    void Start()
    {
        OpenHome();
    }

    public void OpenHome()
    {
        CloseAllPanels();
        homePanel.SetActive(true);
    }

    public void OpenLearning()
    {
        CloseAllPanels();
        learningPanel.SetActive(true);
    }

    public void OpenEarthLayers()
    {
        CloseAllPanels();
        earthLayerPanel.SetActive(true);
    }

    public void OpenQuiz()
    {
        CloseAllPanels();
        quizPanel.SetActive(true);
    }

    public void CloseAllPanels()
    {
        homePanel.SetActive(false);
        learningPanel.SetActive(false);
        earthLayerPanel.SetActive(false);
        quizPanel.SetActive(false);

        if (earthInfoPanel != null)
            earthInfoPanel.SetActive(false);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}

