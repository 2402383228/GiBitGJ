using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextController : MonoBehaviour
{
    [SerializeField] NewPlayer player;
    private RectTransform rectTransform;

    private bool hasRotated = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(player.facingDir == -1 && !hasRotated)
        {
            rectTransform.Rotate(0, 180, 0);
            hasRotated = true;
        }
        else if(player.facingDir == 1 && hasRotated)
        {
            hasRotated = false;
            rectTransform.Rotate(0, 0, 0);
        }
    }
}
