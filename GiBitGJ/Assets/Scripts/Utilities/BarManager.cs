using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    Teleport teleport;

    private void Awake()
    {
        teleport = GetComponent<Teleport>();
    }
    public void OnDialogClick()
    {
        teleport.TeleportToScene();
    }
}
