using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    void Start()
    {
        // ����H1����
        SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
    }


}
