using UnityEngine;

public class TransparencyIncrease : MonoBehaviour
{
    public bool StartFading = false;
    public float fadingDuration = 1f;

    private new Renderer renderer;
    private Material material;
    private float targetAlpha = 0f;
    private float initialAlpha;
    private float fadingTimer = 0f;
    public bool DoActive = true;

    private void Start()
    {
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
}
