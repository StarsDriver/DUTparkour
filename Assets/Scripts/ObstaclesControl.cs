using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControl : MonoBehaviour
{
    private int PosCount;
    private float length;
    private float time;
  //  float[] RoadChoice = { 5.75f, 0.57f, -4.28f };//此处需要相对Map确定
    float[] RoadChoice = { 5.46f, 0.51f, -4.5f };
    public GameObject[] SmallObstacles;
    public GameObject[] BigObstacles;
    public GameObject Map1;
    // Start is called before the first frame update
    void Start()
    {
        //CreateObstacles(Map1,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateObstacles(GameObject map,bool IsSpecialMap)//传入地图
    {
        List<int> ObstaclesPoint = new List<int>();//记录障碍物位置序号  
        length = -map.transform.Find("MapEnd").localPosition.z;//地图的总长度
        GameObject obstacle;
        PosCount = (int)length / 30;//障碍物间隔30，计算一段地图有几个点放障碍物
        if (IsSpecialMap)//判断是否是特殊地图（有斜坡）
        {
            for (int i = 0; i < 3; i++)//三段路
            {
                ObstaclesPoint.Clear();//清空
                for (; ObstaclesPoint.Count <= PosCount/2-2;)//每一路生成二分之一
                {
                    int num = Random.Range(2, PosCount);//随机障碍物生成点
                    if (!ObstaclesPoint.Contains(num))//是否已包含，为了生成互不相同的随机数
                    {
                        ObstaclesPoint.Add(num);
                        obstacle = Instantiate(SmallObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[i], map.transform.position.y+ 10.30859f, map.transform.position.z - num * 30), transform.rotation);
                        //在抽到的位置随机障碍物实例化
                        obstacle.transform.SetParent(map.transform, true);
                        //生成的障碍设置为地图的子物体，将来与地图一起删除
                    }
                }
            }
            ObstaclesPoint.Clear();
            PosCount = (int)length / 35;
            for (; ObstaclesPoint.Count <= PosCount / 2;)
            {
                int num = Random.Range(2, PosCount);
                if (!ObstaclesPoint.Contains(num))
                {
                    ObstaclesPoint.Add(num);
                    obstacle = Instantiate(BigObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[Random.Range(0, 3)], map.transform.position.y+ 10.30859f, map.transform.position.z - num * 35), transform.rotation);
                    obstacle.transform.SetParent(map.transform, true);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                ObstaclesPoint.Clear();
                for (; ObstaclesPoint.Count <= PosCount / 2;)//每一路生成二分之一
                {
                    int num = Random.Range(1, PosCount);
                    if (!ObstaclesPoint.Contains(num))
                    {
                        ObstaclesPoint.Add(num);
                        obstacle = Instantiate(SmallObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[i], map.transform.position.y, map.transform.position.z - num * 30), transform.rotation);
                        obstacle.transform.SetParent(map.transform, true);
                    }
                }
            }
            ObstaclesPoint.Clear();
            PosCount = (int)length / 35;
            for (; ObstaclesPoint.Count <= PosCount / 2;)
            {
                int num = Random.Range(1, PosCount);
                if (!ObstaclesPoint.Contains(num))
                {
                    ObstaclesPoint.Add(num);
                    obstacle = Instantiate(BigObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[Random.Range(0, 3)], map.transform.position.y, map.transform.position.z - num * 35), transform.rotation);
                    obstacle.transform.SetParent(map.transform, true);
                }
            }
        }
    }
}
