using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform TeleportTo;
    public Transform Player;
    public Rigidbody PlayerRb;
    private void OnTriggerEnter(Collider other)
    {
        {
            Player.transform.position = TeleportTo.position;
            PlayerRb.velocity = Vector3.zero;
        }
    }
}
