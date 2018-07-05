
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BeanController : MonoBehaviour
{  

   //初始生成时间5秒钟

//	private GameObject[] bonusObj;
//    private GameObject[] riskObj;
    private int[] addScoreIndex;
    private int[] mapShowIndex;
    private int addScoreNum;
	private int mapShowNum;
    private int gateNum;
    float times = 5f;
    //物体
    public GameObject bean;
    public GameObject risk;
    public GameObject bonus;
    
    GameObject targert = null; 

	//将数量给分配好
	void setNum(int _addScoreNum,int _mapShowNum,int _gateNum)
	{
		this.addScoreNum = _addScoreNum;
		this.mapShowNum = _mapShowNum;
		this.gateNum = _gateNum;
		addScoreIndex = new int[this.addScoreNum];
		mapShowIndex = new int[this.mapShowNum];
	}
   
      
    void PlaceBeans (int startX, int startZ, int length, bool isVertical)
    {
        bean=GameObject.Find("Bean");
        risk=GameObject.Find("Mushroom Monster");
        bonus=GameObject.Find("Bonus");
        int LEFT=1;
        int RIGHT=-1;
        int lr=RIGHT;
        int xx=startX;
        int zz=startZ;
		//bonus有三种类型： 加5分，显示地图，加时间
		//risk有两种类型：减分，减时间
		string[] bonusTag = new string[3];
		string[] riskTag = new string[2];
		bonusTag[0]="bonusAdd5Scores";
		bonusTag[1]="bonusShowMap";
		bonusTag [2] = "bonusAddTime";
		riskTag [0] = "riskMinusScores";   //减少分数随机，3～10
		riskTag[1]="riskMinusTime";
        
//		int bonusObjIndex = 0;
//		int riskObjIndex = 0;
        //road v1
        for(int i=0;i<length;i+=4){

            GameObject obj = (GameObject)Instantiate(bean);//is a bean  
            int ni = Random.Range(1, 100);
			if (ni < 20) {
				obj = (GameObject)Instantiate (bonus);//is a bonus
				int tagIndex=Random.Range(0,2);
				obj.tag = bonusTag[tagIndex];
//				obj.tag = "Bonus";
			} else if (ni < 40) {
				obj = (GameObject)Instantiate (risk);//is a risk
				int tagIndex=Random.Range(0,1);
				obj.tag = riskTag [tagIndex];
//				obj.tag = "Risk";
			} else {
				obj.tag = "Bean";   //Bean会加一分
			}
            if(ni%2==0){
                lr=LEFT;//on the left side of the road
            }
            if(isVertical){
                zz=startZ+lr*4;
                xx=startX+i;
            }
            else{
                zz=startZ+i;
                xx=startX+lr*4;
            }
            obj.transform.position = new Vector3(xx, 1, zz);
        }
		Destroy (bean);
//		Destroy (risk.gameObject);
//		Destroy (bonus);
    }
  
    void Start () 
    {
        // 得在场景中弄一个label来标记关卡是第几关
        int _gateNum=1;   //待改
        switch(_gateNum)
        {
		case 1:
			{
				this.setNum (4, 2, 1);  //分配奖惩数量，待改
				firstWay ();     //设置第一关线路
				for (int i = 0; i < addScoreNum; i++) {
					int index = Random.Range (0, 19);
	            
				}
			}
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			break;
        }
    }


    void Update()
    {        
        
    }
//    GameObject[] getBonusObj()
//    {
//        return bonusObj;
//    }
//	GameObject[] getRiskObj()
//	{
//		return riskObj;
//	}
    void firstWay()
    {
     	PlaceBeans(43,91,180,true);
        PlaceBeans(17,31,170,true);
        PlaceBeans(127,150,60,true);
        PlaceBeans(187,31,120,false);
        PlaceBeans(127,0,150,false);
        PlaceBeans(43,0,120,false);
    }
    void secondWay()
    {

    }
    void thirdWay()
    {

    }
}