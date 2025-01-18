using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine; // ����Cinemachine�����ռ�

public class UIEvent : MonoBehaviour
{
    public TextMeshProUGUI stratText; // ��Ҫ��Inspector������
    public TextMeshProUGUI gameOverText; // ��Ҫ��Inspector������
    public TextMeshProUGUI tryAgainText; // ��Ҫ��Inspector������
    public GameObject player; // ��Ҫ��Inspector������
    public CinemachineVirtualCamera virtualCamera; // ��Ҫ��Inspector������
    public float upwardAcceleration = 3f;
    public float delayTime = 5f;
    public float adjustTime = 2f; // ����ʱ��
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
        // ���������İ���
        if (!isStart && Input.anyKeyDown)
        {
            // ֹͣ���䲢����stratText
            isBlinking = false;
            stratText.gameObject.SetActive(false);

            // ����Player����
            //player.SetActive(true);
            PlayerController2D playerController2D = player.GetComponent<PlayerController2D>();
            playerController2D.upwardAcceleration = upwardAcceleration;

            // ����Э���ӳټ����������
            //StartCoroutine(ActivateVirtualCameraAfterDelay(delayTime));
            // ����Э�̵������������Tracked Object Offset
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
            // ����͸���ȴ�1��0�ٵ�1
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
        // ȷ��stratText��ֹͣ����������ص�
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
        // �ȴ�ָ��������
        yield return new WaitForSeconds(delay);
        // �����������
        virtualCamera.gameObject.SetActive(true);
    }

    IEnumerator AdjustVirtualCameraOffset(float adjustTime)
    {
        yield return null;
    }
}
