using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName] public string sceneFrom;
    [SceneName] public string sceneTo;

    [Header("Arrow")]
    [SerializeField] private string nowColor;
    [SerializeField] private int leftOrRight;

    /// <summary>
    /// 0����1����
    /// </summary>
    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneTo);
    }

    public void TeleportToScene(string _sceneFrom, string _sceneTo)
    {
        TransitionManager.Instance.Transition(_sceneFrom, _sceneTo);
    }

    public void TeleportToSceneArrow()
    {
        int originalIndex = LevelToLevelData.levelToNum[nowColor];
        int toIndex = leftOrRight == 0 ? originalIndex - 1 : originalIndex + 1;
        toIndex = (toIndex + 3) % 3;

        TransitionManager.Instance.Transition(LevelToLevelData.stringArray[originalIndex], LevelToLevelData.stringArray[toIndex]);
    }

    public void TeleportToRedScene()
    {
        TransitionManager.Instance.Transition("DreamScene", "red_level");
    }

    public void TeleportFormMainSceneToNowScene()
    {
        TransitionManager.Instance.Transition("DreamScene", LevelToLevelData.nowLevel);
    }
}
