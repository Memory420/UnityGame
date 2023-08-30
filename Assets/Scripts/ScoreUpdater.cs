using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUpdater : MonoBehaviour
{
    public Score Score;
    public TMP_Text coinsText;

    public ScoreDealer scoreDealerScript;

    private void Update()
    {
        string coinsValue = scoreDealerScript.coins.ToString();
        coinsText.text = "Coins: " + coinsValue;
    }
}
