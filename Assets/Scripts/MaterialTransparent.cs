using TMPro;
using UnityEngine;

public class TransparencyIncrease : MonoBehaviour
{
    public bool StartFading = false;
    public float fadingDuration = 1f;
    public bool Collected = false;

    private new Renderer renderer;
    private Material material;
    private float targetAlpha = 0f;
    private float initialAlpha;
    private float fadingTimer = 0f;
    public bool DoActive = true;
    public ScoreDealer scoredealer;
    public TMP_Text coinsText;

    private void Start()
    {
        scoredealer = GameObject.FindObjectOfType<ScoreDealer>();
        GameObject scoreScreen = GameObject.Find("Экран очков");
        if (scoreScreen != null)
        {
            coinsText = scoreScreen.GetComponent<TMP_Text>();
        }
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        initialAlpha = material.color.a;
    }

    private void Update()
    {
        if (StartFading && DoActive)
        {
            fadingTimer += Time.deltaTime;

            // Вычисление текущего значения альфа-канала
            float currentAlpha = Mathf.Lerp(initialAlpha, targetAlpha, fadingTimer / fadingDuration);

            SetTransparency(currentAlpha);

            if (fadingTimer >= fadingDuration)
            {
                gameObject.SetActive(false);
                return;
            }
        }
    }

    private void SetTransparency(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "PlayerObj" || collision.collider.tag == "Coin")
        {
            string coinsValue = scoredealer.coins.ToString();
            coinsText.text = "Coins: " + coinsValue;
            StartFading = true;
            if (!Collected)
            {
                scoredealer.coins += 1;
            }
            Collected = true;
        }
    }
}
