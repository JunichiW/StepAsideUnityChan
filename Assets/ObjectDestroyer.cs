using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    //カメラのオブジェクト
    private GameObject myCamera;
   
    // Start is called before the first frame update
    void Start()
    {
        //カメラオブジェクトを取得
        this.myCamera = GameObject.Find("Main Camera"); 
    }

    // Update is called once per frame
    void Update()
    {
        //カメラのz軸よりマイナスに位置する（スクリプトをアタッチした）オブジェクトを破棄する
        if (myCamera.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);    
        }
    }
}
