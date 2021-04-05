using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すX方向の範囲
    private float posRange = 3.4f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //最後にアイテムを生成したUnityちゃんの位置
    private float lastGeneratedItemPos = 0;
    //Unityちゃんの進行に応じてアイテムを出すZ方向の範囲
    private int itemPos = 50;
    //Z方向にアイテムを出す間隔
    private int itemInterval = 15;
    //アイテムの生成をやめる判定
    private bool isEndCreateItem = false;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //ゲーム開始時にアイテムを生成
        for (int k = startPos; startPos + itemPos > k; k += itemInterval)
        {
            Createitem(k);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //goalPosでアイテムの生成をやめる
        if (lastGeneratedItemPos + itemInterval > goalPos)
        {
            this.isEndCreateItem = true;
        }
        if (this.isEndCreateItem)
        {
            return;
        }
        //Unityちゃんの進行に応じてアイテムを生成
        if (lastGeneratedItemPos - itemPos <= unitychan.transform.position.z)
        {
            Createitem(lastGeneratedItemPos + itemInterval);
        }
    }

    //アイテムを生成する関数（引数にz座標を渡す）
    void Createitem(float z)
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, z);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムをおくZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置：30％車配置：10％何もなし

                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, z + offsetZ);
                }

                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, z + offsetZ);
                }
            }
        }
                lastGeneratedItemPos = z;
    }
}
