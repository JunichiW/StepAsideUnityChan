using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    //カメラコンポーネント（省略して記述可）
    Camera cam;
   
    // Start is called before the first frame update
    void Start()
    {
        //カメラコンポーネントを取得
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        //カメラのz軸よりマイナスに位置する（スクリプトをアタッチした）オブジェクトを破棄する
        if (cam.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);    
        }
    }
}
