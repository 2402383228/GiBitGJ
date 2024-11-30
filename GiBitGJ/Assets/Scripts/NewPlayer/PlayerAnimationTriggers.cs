using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private NewPlayer player => GetComponentInParent<NewPlayer>();

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
}
