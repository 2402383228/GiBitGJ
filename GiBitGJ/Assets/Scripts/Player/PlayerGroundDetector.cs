using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    PlayerController player;
    public float detectionRadius = 0.1f;
    public LayerMask detectionLayer;
    public bool isGrounded => Physics2D.OverlapCircle(transform.position, detectionRadius, detectionLayer);

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

}
