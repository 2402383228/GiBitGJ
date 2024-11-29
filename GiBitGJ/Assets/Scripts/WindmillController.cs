using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        if(LevelToLevelData.windmillSum == 0)
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

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSelf") && Input.GetKeyDown(KeyCode.E) && !LevelToLevelData.windmillHasBeenTouch[WindmillOrder])
        {
            LevelToLevelData.windmillSum++;
            LevelToLevelData.windmillHasBeenTouch[WindmillOrder] = true;

            if(LevelToLevelData.windmillSum == 0)
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
}
