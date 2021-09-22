using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public int hp;//体力
    int turnTime = 3;
    float timecount;
    bool rotateflag;
    int LR;//左右どちらに曲がるか
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
        timecount += Time.deltaTime;
        if(mode == Mode.idle)//待機状態
        {
            //移動なし
        }
        if (mode == Mode.relax)//基本の移動
        {
            //前移動
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //何秒かごとに旋回
            if(timecount >= turnTime)
            {
                timecount = 0;
                rotateflag = true;
                LR = Random.Range(1, 3);
                Debug.Log(LR);
            }
            if (rotateflag == true && LR == 1)
            {
                transform.Rotate(0, 0, -1 * rotateSpeed);
                transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
                if(timecount >= 0.5f)
                {
                    rotateflag = false;
                }
            }
            if (rotateflag == true && LR != 1)
            {
                transform.Rotate(0, 0, 1 * rotateSpeed);
                transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
                if (timecount >= 0.5f)
                {
                    rotateflag = false;
                }
            }
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
