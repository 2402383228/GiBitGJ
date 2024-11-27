using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DialogManager : MonoBehaviour
{
    public Gamemaneger gamemaneger;

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
        for (int i = 0; i < dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                dialogIndex = int.Parse(cells[5]);
                nextButton.gameObject.SetActive(true);
                break;
            }
            else if (cells[0] == "$" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);
                Operate(cells[6]);
                break;
            }
            else if (cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
            {
                nextButton.gameObject.SetActive(false);
                GenerateOption(i);
            }
            else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
            {
                Debug.Log("Over");
                teleport.TeleportToScene();
            }
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
        itemManager.canMentionBracelet = true;
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
            if (itemManager.isMentionBracelet)
            {
                dialogIndex = 16;
            }
            else
            {
                dialogIndex = 17;
            }
        }
    }
}