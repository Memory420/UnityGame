using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUpdater : MonoBehaviour
{
    public Score Score;
    public TMP_Text coinsText;

    private ScoreDealer scoreDealerScript;

    private void Start()
    {
        coinsText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        string coinsValue = scoreDealerScript.coins.ToString();
        coinsText.text = "Coins: " + coinsValue;
    }
}
