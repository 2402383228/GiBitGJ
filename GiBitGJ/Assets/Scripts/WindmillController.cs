using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindmillController : MonoBehaviour
{
    [SerializeField] private Sprite Windmill0;
    [SerializeField] private Sprite Windmill1;
    [SerializeField] private Sprite Windmill2;
    [SerializeField] private Sprite Windmill3;
    [SerializeField] private Sprite Windmill4;

    [Space]
    [SerializeField] private int WindmillOrder;

    private Material outlineMaterial; // Add a reference to the outline material

    private bool isPlayerInTrigger = false;
    private bool hasE = false;
    private TMP_Text playerText;

    void Start()
    {
        playerText = GetComponentInChildren<TMP_Text>();

        if (LevelToLevelData.windmillSum == 0)
        {
            GetComponent<SpriteRenderer>().sprite = Windmill0;
        }
        else if(LevelToLevelData.windmillSum == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Windmill1;
        }
        else if(LevelToLevelData.windmillSum == 2)
        {
            GetComponent<SpriteRenderer>().sprite = Windmill2;
        }
        else if(LevelToLevelData.windmillSum == 3)
        {
            GetComponent<SpriteRenderer>().sprite = Windmill3;
        }
        else if(LevelToLevelData.windmillSum == 4)
        {
            GetComponent<SpriteRenderer>().sprite = Windmill4;
        }

        if(LevelToLevelData.windmillHasBeenTouch[WindmillOrder])
        {
            // Get the renderer component of the object
            Renderer renderer = GetComponent<Renderer>();

            // Create a new material instance for the outline material
            outlineMaterial = new Material(Shader.Find("Outlined/Silhouetted Diffuse"));

            // Assign the outline material to the renderer
            renderer.material = outlineMaterial;
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && !hasE && !LevelToLevelData.windmillHasBeenTouch[WindmillOrder])
        {
            playerText.text = "按E进行交互";
        }
        else if (isPlayerInTrigger && !hasE && LevelToLevelData.windmillHasBeenTouch[WindmillOrder])
        {
            playerText.text = "这个风车已经被点亮了";
        }

        if (!isPlayerInTrigger)
        {
            playerText.text = "";
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !LevelToLevelData.windmillHasBeenTouch[WindmillOrder])
        {
            hasE = true;
            LevelToLevelData.windmillSum++;
            LevelToLevelData.windmillHasBeenTouch[WindmillOrder] = true;

            if(LevelToLevelData.windmillSum == 4)
            {
                playerText.text = "所有风车已经被点亮，但似乎还藏着一个谜题";

                StartCoroutine(DelayedTextClear(2f));
            }
            else if(LevelToLevelData.windmillSum < 4)
            {
                playerText.text = "风车被点亮了";

                StartCoroutine(DelayedTextClear(2f));
            }

            if (LevelToLevelData.windmillSum == 0)
            {
                GetComponent<SpriteRenderer>().sprite = Windmill0;
            }
            else if (LevelToLevelData.windmillSum == 1)
            {
                GetComponent<SpriteRenderer>().sprite = Windmill1;
            }
            else if (LevelToLevelData.windmillSum == 2)
            {
                GetComponent<SpriteRenderer>().sprite = Windmill2;
            }
            else if (LevelToLevelData.windmillSum == 3)
            {
                GetComponent<SpriteRenderer>().sprite = Windmill3;
            }
            else if (LevelToLevelData.windmillSum == 4)
            {
                GetComponent<SpriteRenderer>().sprite = Windmill4;

                //解开风车谜题获得发簪
                InventoryManager.Instance.AddItem(ItemName.Hairpin);
            }

            if (LevelToLevelData.windmillHasBeenTouch[WindmillOrder])
            {
                // Get the renderer component of the object
                Renderer renderer = GetComponent<Renderer>();

                // Create a new material instance for the outline material
                outlineMaterial = new Material(Shader.Find("Outlined/Silhouetted Diffuse"));

                // Assign the outline material to the renderer
                renderer.material = outlineMaterial;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("PlayerSelf"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.CompareTag("PlayerSelf"))
        {
            isPlayerInTrigger = false;
        }
    }

    private IEnumerator DelayedTextClear(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerText.text = "";

        hasE = false;
    }
}
