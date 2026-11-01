
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LearningManager : MonoBehaviour
{
    [Header("Learning UI")]
    public GameObject learningPanel;
    public TextMeshProUGUI learningTitle;
    public TextMeshProUGUI learningContent;
    public TextMeshProUGUI learningCodeText;

    [Header("Navigation Buttons")]
    public Button nextButton;
    public Button previousButton;

    [Header("3D Earth Model")]
    public GameObject learningEarth;

    private int currentStep = 0;

    private string[] contents =
    {
        "STEP 1: UNDERSTANDING EARTH'S ROTATION\n\n" +
        "Earth rotates around an imaginary line called its axis.\n\n" +
        "One complete rotation takes approximately 24 hours.\n\n" +
        "This rotation causes day and night.",

        "STEP 2: DIRECTION OF ROTATION\n\n" +
        "Earth rotates from west to east.\n\n" +
        "This makes the Sun appear to rise in the east and set in the west.",

        "STEP 3: DAY AND NIGHT\n\n" +
        "The side of Earth facing the Sun experiences daytime.\n\n" +
        "The opposite side experiences nighttime.",

        "STEP 4: SEE EARTH ROTATING\n\n" +
        "Observe the 3D Earth model rotating around its axis.\n\n" +
        "This animation demonstrates Earth's rotation."
    };

    private string[] code =
    {
        "<color=yellow>void Update()</color>\n{\n    transform.Rotate(Vector3.up * 20f * Time.deltaTime);\n}",

        "void Update()\n{\n    <color=yellow>transform.Rotate</color>(Vector3.up * 20f * Time.deltaTime);\n}",

        "// Earth's rotation causes day and night\n\n<color=yellow>transform.Rotate(Vector3.up * 20f * Time.deltaTime);</color>",

        "void Update()\n{\n    <color=yellow>transform.Rotate(Vector3.up * 20f * Time.deltaTime);</color>\n}"
    };

    void Start()
    {
        nextButton.onClick.AddListener(NextStep);
        previousButton.onClick.AddListener(PreviousStep);

        ShowStep();
    }

    void ShowStep()
    {
        learningTitle.text = "EARTH ROTATION";

        learningContent.text = contents[currentStep];

        learningCodeText.text = code[currentStep];

        previousButton.interactable = currentStep > 0;

        nextButton.interactable = currentStep < contents.Length - 1;

        if (learningEarth != null)
        {
            learningEarth.SetActive(currentStep == 3);

            EarthRotation rotation =
                learningEarth.GetComponent<EarthRotation>();

            if (rotation != null)
            {
                rotation.enabled = currentStep == 3;
            }
        }
    }

    void NextStep()
    {
        if (currentStep < contents.Length - 1)
        {
            currentStep++;
            ShowStep();
        }
    }

    void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            ShowStep();
        }
    }
}

