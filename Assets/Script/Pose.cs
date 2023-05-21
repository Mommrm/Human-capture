using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose : MonoBehaviour
{
    public Socket udpReceive;
    public GameObject[] BodyPoints;
    void Start()
    {

    }
    void Update()
    {
        string data = udpReceive.data;
        //去除开头和末尾的[]
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        //分割坐标点,并传入字符串数组中
        string[] points = data.Split(',');
        Debug.Log(points[32]);
        
        
        
        
        //每个point是以3为倍数的x,y,z分布 一共有96(下标从0到96)的长度
        for (int i = 0; i < 32; i++)
        {

            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            BodyPoints[i].transform.localPosition = new Vector3(x, y, z);

        }

    }
}
