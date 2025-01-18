using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartEvent : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // ��Ҫ��Inspector������
    public GameObject player; // ��Ҫ��Inspector������
    public GameObject virtualCamera; // ��Ҫ��Inspector������
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
        // ���������İ���
        if (Input.anyKeyDown)
        {
            // ֹͣ���䲢����TextMeshPro
            isBlinking = false;
            textMeshPro.gameObject.SetActive(false);

            // ����Player����
            player.SetActive(true);

            // ����Э���ӳټ����������
            StartCoroutine(ActivateVirtualCameraAfterDelay(delayTime));
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
        // ȷ��TextMeshPro��ֹͣ����������ص�
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
        // �ȴ�ָ��������
        yield return new WaitForSeconds(delay);
        // �����������
        virtualCamera.SetActive(true);
    }
}

