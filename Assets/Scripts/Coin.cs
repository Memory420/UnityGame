using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Options")]
    public float distantToActivate = 0.5f;
    public Rigidbody rb;
    public Transform coinObject;
    public Transform playerObject;
    public TransparencyIncrease transparencyIncreaseScript;
    public ScoreDealer scoreDealerScript;
    public bool Collected;

    private void Awake()
    {
        transparencyIncreaseScript = GetComponent<TransparencyIncrease>();
        coinObject = GetComponent<Transform>();
        GameObject player = GameObject.Find("Player");
        rb = coinObject.GetComponent<Rigidbody>();
        scoreDealerScript = GetComponent<ScoreDealer>();

        GameObject scoreObject = GameObject.Find("Score");
        if (scoreObject != null)
        {
            scoreDealerScript = scoreObject.GetComponent<ScoreDealer>();
        }
        else
        {
            Debug.LogError("Score object not found!");
        }

        if (player != null)
        {
            playerObject = player.transform;
        }
    }
    private void Update()
    {
        if((Vector3.Distance(coinObject.position, playerObject.position) < distantToActivate) && !Collected)
        {
            Debug.Log("Триггер");
            transparencyIncreaseScript.StartFading = true;
            rb.isKinematic = false;
            scoreDealerScript.coins++;
            Collected = true;
        }       
    }
}
