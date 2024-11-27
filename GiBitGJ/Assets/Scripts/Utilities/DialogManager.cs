using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DialogManager : MonoBehaviour
{
    public Teleport teleport;
    public ItemManager itemManager;
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
        imageDic["A"] = sprites[0];
        imageDic["B"] = sprites[1];
    }

    void Start()
    {
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
        if (_position == "左")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if (_position == "右")
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
        else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
        {
            if (itemManager.isMentionBracelet == 0)
            {
                dialogIndex = 13;
            }
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
        itemManager.canMentionBracelet = 1;
    }

    public void Operate(string operation)
    {
        if (operation == "看到手镯")
        {
            SeeBracelet();
            dialogIndex++;
            nextButton.gameObject.SetActive(true);
        }
        else if (operation == "跳转")
        {
            if (itemManager.isMentionBracelet == 1)
            {
                dialogIndex = 16;
            }
            else
            {
                dialogIndex = 17;
            }
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
}