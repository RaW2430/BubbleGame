using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public enum EffectType
    {
        Scale = 0,
        Rotate = 1,
        // ����Ч����ſ������������
    }

    public EffectType effectType;
    public float rotateSpeed = 5.0f;
    public float scaleSpeed = 3.0f;
    public Vector2 scaleRange = new Vector2(0.8f, 1.2f); // �����ķ������ʷ�Χ
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale; // ��¼��ʼ�� localScale
    }

    private void Update()
    {
        switch (effectType)
        {
            case EffectType.Rotate:
                ApplyRotateEffect();
                break;
            case EffectType.Scale:
                ApplyScaleEffect();
                break;
                // ����Ч���Ĵ���������������
        }
    }

    private void ApplyRotateEffect()
    {
        float angle = -20 * (Mathf.Cos(Time.time * rotateSpeed) + 1);
        //Debug.Log(Time.time + " " + Mathf.Sin(Time.time) + " " + angle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void ApplyScaleEffect()
    {
        float scaleMultiplier = Mathf.Lerp(scaleRange.x, scaleRange.y, (Mathf.Sin(Time.time * scaleSpeed) + 1) / 2);
        transform.localScale = initialScale * scaleMultiplier; // ���ڳ�ʼ�� localScale ���з���
    }
}

