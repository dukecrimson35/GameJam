using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed;
    public int hp;//体力
    enum Mode 
    { 
        idle,//動かない
        careful,//警戒
        relax//通常
    };
    Mode mode;

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.relax;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == Mode.idle)//待機状態
        {
            //移動なし
        }
        if (mode == Mode.relax)//基本の移動
        {
            //前移動
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //何秒かごとに旋回
            
        }
        if(mode == Mode.careful)//プレイヤーに気づいたとき
        {
            //逃げるように移動
        }

        #region 消滅処理
        if(hp <= 0)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
        #endregion
    }

    public void Damage(int damage)//攻撃された
    {
        hp -= damage;
    }
}
