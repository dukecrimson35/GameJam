using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float runSpeed;
    public int hp;//体力
    int turnTime = 1;
    float timecount;
    bool rotateflag;
    int LR;//左右どちらに曲がるか
    GameObject Hirame;

    enum Mode 
    { 
        idle,//動かない
        careful,//警戒
        relax//通常
    };
    Mode mode;

    Vector3 hirameposLocal;
    HirameMove hirameScript;

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.relax;
        if (turnTime <= 1)
        {
            turnTime = Random.Range(2, 6);
        }
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
                turnTime = Random.Range(2, 6);
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
            if (hirameScript.GetHideMater() < 0.9f)
            {
                //逃げるように移動
                hirameposLocal = transform.InverseTransformPoint(Hirame.transform.position);//ヒラメの位置を相対座標で取得
                                                                                            //ヒラメが右にいる場合
                if (hirameposLocal.x > 0)
                {
                    //左旋回
                    transform.Rotate(0, 0, 1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * runSpeed;
                }
                //ヒラメが左にいる場合
                if (hirameposLocal.x < 0)
                {
                    //右旋回
                    transform.Rotate(0, 0, -1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * runSpeed;
                }
                //ヒラメが正面
                if (hirameposLocal.x == 0)
                {
                    //突進
                    transform.position += transform.up * 1f * Time.deltaTime * runSpeed * 1.5f;
                }
            }
            if(hirameScript.GetHideMater() >= 0.9f)
            {
                mode = Mode.relax;
            }
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

    public void ChangeRunmode()
    {
        mode = Mode.careful;
    }

    public void ChangeRelaxmode()
    {
        mode = Mode.relax;
    }

    public void GetHirame(GameObject hirame)
    {
        Hirame = hirame;
    }

    public void GetHirameScript(GameObject hirame)
    {
        if(hirameScript == null)
        {
            hirameScript = hirame.GetComponent<HirameMove>();
        }
    }
}
