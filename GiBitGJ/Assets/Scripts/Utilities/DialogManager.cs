using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DialogManager : MonoBehaviour
{
    public Teleport teleport;
    public Canvas canvas;
    public ItemManager itemManager;
    public SelectionManager selectionManager;
    public TextAsset dialogDataFile;
    public SpriteRenderer spriteLeft;
    public SpriteRenderer spriteRight;
    public TMP_Text nameText;
    public TMP_Text dialogText;
    public List<Sprite> sprites = new List<Sprite>();
    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    public int dialogIndex;
    public string[] dialogRows;
    public Button nextButton;
    public GameObject optionButton;
    public Transform buttonGroup;

    void Awake()
    {
        imageDic["NPC："] = sprites[0];
        imageDic["玩家："] = sprites[1];
    }

    void Start()
    {
        ShowCanvas();
        ReadText(dialogDataFile);
        ShowDialogRow();
    }

    void OnEnable()
    {
        LoadDialog();
    }

    void OnDisable()
    {
        SaveDialog();
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false); 
    }


    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void CleanImage()
    {
        spriteLeft.sprite = null;
        spriteRight.sprite = null;
    }

    public void UpdateImage(string _name, string _position)
    {
        if (_name == "NPC：")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if (_name == "玩家：")
        {
            spriteRight.sprite = imageDic[_name];
        }
    }

    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
    }

    public void ShowDialogRow()
    {
        string[] cells = dialogRows[dialogIndex].Split(',');
        if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
        {
            UpdateText(cells[2], cells[4]);
            UpdateImage(cells[2], cells[3]);

            dialogIndex = int.Parse(cells[5]);
            nextButton.gameObject.SetActive(true);
        }
        else if (cells[0] == "$" && int.Parse(cells[1]) == dialogIndex)
        {
            UpdateText(cells[2], cells[4]);
            UpdateImage(cells[2], cells[3]);
            Operate(cells[6]);
        }
        else if (cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
        {
            nextButton.gameObject.SetActive(false);
            GenerateOption(dialogIndex);
        }
        else if (cells[0] == "SELECTION" && int.Parse(cells[1]) == dialogIndex)
        {
            ShowSelection();
        }
        else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
        {
            teleport.TeleportToScene();
        }
    }

    public void OnClickNext()
    {
        ShowDialogRow();
    }

    public void GenerateOption(int _index)
    {
        string[] cells = dialogRows[_index].Split(',');
        if (cells[0] == "&")
        {
            GameObject button = Instantiate(optionButton, buttonGroup);
            button.GetComponentInChildren<TMP_Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener(
            delegate
            {
                OnOptionClick(int.Parse(cells[5]));
            });
            GenerateOption(_index + 1);
        }
    }

    public void OnOptionClick(int _id)
    {
        dialogIndex = _id;
        ShowDialogRow();
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }

    public void SeeBracelet()
    {
        ItemManager.canMentionBracelet = 1;
    }

    public void Operate(string operation)
    {
        if (operation == "看到手镯")
        {
            SeeBracelet();
            dialogIndex++;
            nextButton.gameObject.SetActive(true);
        }
    }
    private void SaveDialog()
    {
        PlayerPrefs.SetInt("dialogIndex", dialogIndex - 1);
    }

    private void LoadDialog()
    {
        dialogIndex = PlayerPrefs.GetInt("dialogIndex", 1);
    }

    public void ShowSelection()
    {
        CloseCanvas();
        selectionManager.ShowCanvas();
    }

    public void CloseSelection()
    {
        selectionManager.CloseCanvas();
        ShowCanvas();
    }

    public void ShowTargetDialog()
    {
        dialogIndex = 18;
        ShowDialogRow();
    }

    public void ShowOverDialog()
    {
        dialogIndex = 30;
        ShowDialogRow();
    }

    public void OnOverClick()
    {
        CloseSelection();
        ShowOverDialog();
    }
}