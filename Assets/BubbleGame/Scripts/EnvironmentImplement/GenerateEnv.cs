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
    public List<SOlis> soLis;

    //生成的开始和结束位置
    public float generateBeginY = -160f;
    public float generateEndY = -110f;
    public float generateDistance = 50f;

    private List<float> lastGenerateYs;

    private void Awake()
    {
        //从资源中加载所有的GenerateSO
        GenerateSO[] generateSOArray = Resources.LoadAll<GenerateSO>("GenerateSO");
        SOlis[] soLisArray = Resources.LoadAll<SOlis>("Solis");
        generateSOs = new List<GenerateSO>(generateSOArray);
        soLis = new List<SOlis>(soLisArray);
        lastGenerateYs = new List<float>();
        for (int i = 0; i < generateSOs.Count; i++)
        {
            lastGenerateYs.Add(player.position.y + generateDistance);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }
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
        /*for (int i = 0; i < generateSOs.Count; i++)
        {
            while (lastGenerateYs[i] < generateEndY)
            {
                lastGenerateYs[i] += generateSOs[i].distance;
                float posX = UnityEngine.Random.Range(-7f, 7f);
                if (generateSOs[i].objectType == ObjectType.CheckPoint) posX = 0;
                Vector3 pos = new Vector3(posX, lastGenerateYs[i], generateSOs[i].prefab.transform.position.z);
                var obj=Instantiate(generateSOs[i].prefab, pos, Quaternion.identity);
                var randomParameter = obj.GetComponent<RandomParameter>();
                if (randomParameter != null)
                {
                    randomParameter.GenerateRandomParameter();
                }
            }
        }*/
        for (int i = 0; i < soLis.Count; i++)
        {
            //从里面随机选一个
            int index = UnityEngine.Random.Range(0, soLis[i].generateSOs.Count);
            var so = soLis[i].generateSOs[index];
            //从范围里面随机一个位置
            float posX = UnityEngine.Random.Range(-7f, 7f);
            if(lastGenerateYs[i]+so.distance>generateEndY)
            {
                continue;
            }
            float posY = UnityEngine.Random.Range(generateBeginY, generateEndY);
            if(posY-lastGenerateYs[i]<so.distance)
            {
                posY = lastGenerateYs[i] + so.distance;
            }
            if (so.objectType == ObjectType.CheckPoint) posX = 0;
            Vector3 pos = new Vector3(posX, posY, so.prefab.transform.position.z);
            var obj = Instantiate(so.prefab, pos, Quaternion.identity);
            var randomParameter = obj.GetComponent<RandomParameter>();
            if (randomParameter != null)
            {
                randomParameter.GenerateRandomParameter();
            }
            lastGenerateYs[i] = posY;
        }

}
}
