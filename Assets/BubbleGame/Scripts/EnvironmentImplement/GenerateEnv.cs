using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RandomParameter
{
    public void GenerateRandomParameter();
}

public class GenerateEnv : MonoBehaviour
{
    public Transform player;
    public List<GenerateSO> generateSOs;

    //生成的开始和结束位置
    public float generateBeginY = -160f;
    public float generateEndY = -110f;
    public float generateDistance = 50f;

    private List<float> lastGenerateYs;

    private void Awake()
    {
        //从资源中加载所有的GenerateSO
        GenerateSO[] generateSOArray = Resources.LoadAll<GenerateSO>("GenerateSO");
        //generateSOs = new List<GenerateSO>(generateSOArray);
        lastGenerateYs = new List<float>();
        for (int i = 0; i < generateSOs.Count; i++)
        {
            lastGenerateYs.Add(player.position.y + generateDistance);
        }
    }

    private void Update()
    {
        if(player.position.y > (generateBeginY+generateEndY)/2)
        {
            Debug.Log("Generate");
            Generate();
        }
    }

    void Generate()
    {
        generateBeginY += generateDistance;
        generateEndY += generateDistance;
        for (int i = 0; i < generateSOs.Count; i++)
        {
            while (lastGenerateYs[i] < generateEndY)
            {
                lastGenerateYs[i] += generateSOs[i].distance;
                Vector3 pos = new Vector3(UnityEngine.Random.Range(-10f, 10f), lastGenerateYs[i], generateSOs[i].prefab.transform.position.z);
                var obj=Instantiate(generateSOs[i].prefab, pos, Quaternion.identity);
                var randomParameter = obj.GetComponent<RandomParameter>();
                if (randomParameter != null)
                {
                    randomParameter.GenerateRandomParameter();
                }
            }
        }
        
    }
}
