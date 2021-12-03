using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField]
    private Text _textField;

    [SerializeField]
    private VerticalLayoutGroup _choiceButtonContainer;

    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private Color _normalTextColor;

    [SerializeField]
    private Color _thoughtTextColor;

    private int _mentalHealth;
    private InkManager _inkManager;
    public SpriteRenderer Fine;
    public Sprite Happy;
    public Sprite Worried;
    public Sprite Normal;

    public Text _MentalHealth;
    public int MentalHealth
    {
        get => _mentalHealth;
        private set
        {
            Debug.Log($"Updating MentalHealth value. Old value: {_mentalHealth}, new value: {value}");
            _mentalHealth = value;
        }
    }

    public GameObject BtnRoom;
    private SpriteRenderer spriteRenderer;
   
   

    void Start()
    {
        _inkManager = FindObjectOfType<InkManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

         StartStory();
    }

    private void SetHealthInUI(int newValue)
    {
        throw new System.NotImplementedException();
    }

    private void StartStory()
    {
        _story = new Story(_inkJsonAsset.text);


        var mentalHealth = (int)_story.variablesState["mental_health"];

        Debug.Log($"Logging ink variables. mental health: {mentalHealth}");
        DisplayNextLine();
    }


    private void InitializeVariables()
    {

        MentalHealth = (int)_story.variablesState["mental_health"];

        _story.ObserveVariable("mental_health", (arg, value) =>
        {
            MentalHealth = (int)value;
            Debug.Log("value changing");
        });
    }

    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            string text = _story.Continue(); // gets next line

            text = text?.Trim(); // removes white space from text

            ApplyStyling();
            ShowCharacter();


            _textField.text = text; // displays new text
        }
        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else if (_story.canContinue == false)
        {
            Debug.Log("Story has ended!");
            SpawnButton();
            MentalH();

        }
    }

    public void DisplayChoices()
    {
        // checks if choices are already being displaye
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++) // iterates through all choices
        {

            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); // creates a choice button

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        // creates the button from a prefab
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        // sets text on the button
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        RefreshChoiceView(); // removes choices from the screen
        DisplayNextLine();

    }

    void RefreshChoiceView()
    {
        if (_choiceButtonContainer != null)
        {
            foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    public void ApplyStyling()
    {
        if (_story.currentTags.Contains("thought"))
        {
            _textField.color = _thoughtTextColor;
            _textField.fontStyle = FontStyle.Italic;
        }
        else
        {
            _textField.color = _normalTextColor;
            _textField.fontStyle = FontStyle.Normal;
        }
    }

    public void ShowCharacter()
    {

        {
            if (_story.currentTags.Contains("Happy"))
            {
                ChangeSprite(Happy);
            }
            else if(_story.currentTags.Contains("Worried"))
            {
                ChangeSprite(Worried);
            }
            else if(_story.currentTags.Contains("Normal"))
            {
                ChangeSprite(Normal);
            }
            {
                Debug.Log("No Tag found");
            }



            void ChangeSprite(Sprite newSprite)
            {
                Fine.sprite = newSprite;
                Debug.Log("Sprite Changed");
            }
        }
    }

    public void SpawnButton()
    {
        Instantiate(BtnRoom, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Button Spawned");
    }

    //This fumction just helps check the variables for
   // the different outcomes
    public void MentalH()
    {
       if(MentalHealth <= 50)
        {
            Debug.Log("Mental Health not so good");
        }
        else if (MentalHealth > 50)
        {
            Debug.Log("Mental health good");
        }
       
    }

}


    

