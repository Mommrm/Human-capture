using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Socket udpReceive;
    public GameObject[] handPoints;
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

        //每个point是以3为倍数的x,y,z分布 一共有63(下标从0到62)的长度
        for (int i = 0; i < 21; i++)
        {

            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);

        }

    }
}

