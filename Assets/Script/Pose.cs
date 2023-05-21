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
        //ȥ����ͷ��ĩβ��[]
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        //�ָ������,�������ַ���������
        string[] points = data.Split(',');
        Debug.Log(points[32]);
        
        
        
        
        //ÿ��point����3Ϊ������x,y,z�ֲ� һ����96(�±��0��96)�ĳ���
        for (int i = 0; i < 32; i++)
        {

            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            BodyPoints[i].transform.localPosition = new Vector3(x, y, z);

        }

    }
}
