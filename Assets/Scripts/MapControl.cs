using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    private Transform CreatePoint;//新地图加载的位置
    private GameObject NewMap;//需要加载的新地图
    private int MapCount;//记录随机到的地图序号
    private Queue<GameObject> Map=new Queue<GameObject>();//存放当前地图
    public GameObject Map1;//初始的地图
    ObstaclesControl Obs;
    bool IsSpecialMap;
    void Start()
    {
        Map.Enqueue(Map1);
        Obs = GameObject.Find("ObstaclesControl").GetComponent<ObstaclesControl>();//获取控制障碍物的组件
        CreatePoint = Map1.transform.Find("MapEnd");//获取初始地图的终点
        for(int i=0;i<3;i++)
        {
            CreateMap(ref CreatePoint);
        }
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="MapEnd")
        {
            CreateMap(ref CreatePoint);
            Destroy(Map.Dequeue());
        }
    }
    private void CreateMap(ref Transform CreatPoint)//引用参数
    {
        MapCount =  Random.Range(1, 8);
        if(MapCount==2||MapCount==3)//判断是否是特殊地图
        {
            IsSpecialMap = true;
        }else
        {
            IsSpecialMap = false;
        }
        NewMap = Instantiate(Resources.Load<GameObject>("Map" + MapCount), CreatePoint.position, CreatePoint.rotation);//实例化新地图
        Map.Enqueue(NewMap);//新地图入队
        CreatePoint = NewMap.transform.Find("MapEnd");//获取新地图的末尾
        Obs.CreateObstacles(NewMap,IsSpecialMap);
       
    }
}
