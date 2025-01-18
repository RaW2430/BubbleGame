using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine; // 引入Cinemachine命名空间

public class UIEvent : MonoBehaviour
{
    public TextMeshProUGUI stratText; // 需要在Inspector中设置
    public TextMeshProUGUI gameOverText; // 需要在Inspector中设置
    public TextMeshProUGUI tryAgainText; // 需要在Inspector中设置
    public GameObject player; // 需要在Inspector中设置
    public CinemachineVirtualCamera virtualCamera; // 需要在Inspector中设置
    public float upwardAcceleration = 3f;
    public float delayTime = 5f;
    public float adjustTime = 2f; // 调整时间
    private bool isStart = false;
    private bool isDead = false;
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
        if (!isStart && Input.anyKeyDown)
        {
            // 停止渐变并隐藏stratText
            isBlinking = false;
            stratText.gameObject.SetActive(false);

            // 激活Player对象
            //player.SetActive(true);
            PlayerController2D playerController2D = player.GetComponent<PlayerController2D>();
            playerController2D.upwardAcceleration = upwardAcceleration;

            // 启动协程延迟激活虚拟相机
            //StartCoroutine(ActivateVirtualCameraAfterDelay(delayTime));
            // 启动协程调整虚拟相机的Tracked Object Offset
            StartCoroutine(AdjustVirtualCameraOffset(adjustTime));
            isStart = true;
        }
        if (isStart && isDead && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        // 确保stratText在停止渐变后是隐藏的
        SetTextAlpha(0);
    }

    public void RestartGame()
    {
        gameOverText.gameObject.SetActive(true);
        tryAgainText.gameObject.SetActive(true);
        isDead = true;
    }
    private void SetTextAlpha(float alpha)
    {
        Color color = stratText.color;
        color.a = alpha;
        stratText.color = color;
    }

    IEnumerator ActivateVirtualCameraAfterDelay(float delay)
    {
        // 等待指定的秒数
        yield return new WaitForSeconds(delay);
        // 激活虚拟相机
        virtualCamera.gameObject.SetActive(true);
    }

    IEnumerator AdjustVirtualCameraOffset(float adjustTime)
    {
        yield return null;
    }
}
