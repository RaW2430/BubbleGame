using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTipsEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f; // ��˸���ʱ��

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            StartCoroutine(BlinkCoroutine());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            // ��͸����255��0
            for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime / blinkInterval)
            {
                SetAlpha(alpha);
                yield return null;
            }

            // ��͸����0��255
            for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime / blinkInterval)
            {
                SetAlpha(alpha);
                yield return null;
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
