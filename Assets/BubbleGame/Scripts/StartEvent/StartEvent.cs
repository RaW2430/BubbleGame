using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartEvent : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // 需要在Inspector中设置
    public GameObject player; // 需要在Inspector中设置
    public GameObject virtualCamera; // 需要在Inspector中设置
    public float delayTime = 5f;
    private bool isBlinking = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeText());
    }

    // Update is called once per frame
    void Update()
    {
        // 检测任意键的按下
        if (Input.anyKeyDown)
        {
            // 停止渐变并隐藏TextMeshPro
            isBlinking = false;
            textMeshPro.gameObject.SetActive(false);

            // 激活Player对象
            player.SetActive(true);

            // 启动协程延迟激活虚拟相机
            StartCoroutine(ActivateVirtualCameraAfterDelay(delayTime));
        }
    }

    IEnumerator FadeText()
    {
        while (isBlinking)
        {
            // 渐变透明度从1到0再到1
            for (float alpha = 1; alpha >= 0; alpha -= 0.05f)
            {
                SetTextAlpha(alpha);
                yield return new WaitForSeconds(0.05f);
            }
            for (float alpha = 0; alpha <= 1; alpha += 0.05f)
            {
                SetTextAlpha(alpha);
                yield return new WaitForSeconds(0.05f);
            }
        }
        // 确保TextMeshPro在停止渐变后是隐藏的
        SetTextAlpha(0);
    }

    void SetTextAlpha(float alpha)
    {
        Color color = textMeshPro.color;
        color.a = alpha;
        textMeshPro.color = color;
    }

    IEnumerator ActivateVirtualCameraAfterDelay(float delay)
    {
        // 等待指定的秒数
        yield return new WaitForSeconds(delay);
        // 激活虚拟相机
        virtualCamera.SetActive(true);
    }
}

