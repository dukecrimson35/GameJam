using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float huntSpeed;
    int turnTime =3;
    float timecount;
    bool rotateflag;
    int LR;//左右どちらに曲がるか

    GameObject Hirame;
    HirameMove hirameScript;

    enum Mode
    {
        idle,//動かない
        hunt,//警戒
        relax//通常
    };
    Mode mode;

    Vector3 hirameposLocal;

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.relax;
        if(turnTime <= 1)
        {
            turnTime = Random.Range(2, 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timecount += Time.deltaTime;
        #region 通常移動
        if (mode == Mode.idle)
        {
            //移動しない
        }
        if (mode == Mode.relax)
        {
            //前移動
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //何秒かごとに旋回
            if (timecount >= turnTime)
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
                if (timecount >= 0.5f)
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
        #endregion

        #region 追いかけモード
        if(mode == Mode.hunt)
        {
            if (hirameScript.GetHideMater() < 0.9f)
            {
                hirameposLocal = transform.InverseTransformPoint(Hirame.transform.position);//ヒラメの位置を相対座標で取得
                //ヒラメが右にいる場合
                if (hirameposLocal.x > 0)
                {
                    //右旋回
                    transform.Rotate(0, 0, -1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed;
                }
                //ヒラメが左にいる場合
                if (hirameposLocal.x < 0)
                {
                    //左旋回
                    transform.Rotate(0, 0, 1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed;
                }
                //ヒラメが正面
                if (hirameposLocal.x == 0)
                {
                    //突進
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed * 1.5f;
                }
            }
            else
            {
                mode = Mode.relax;
            }
        }
        #endregion
    }

    public void ChangeMode()
    {
        if(mode == Mode.relax)
        {
            mode = Mode.hunt;
        }
        if(mode == Mode.hunt)
        {
            mode = Mode.relax;
        }
    }

    public void ChangeHuntmode()
    {
        mode = Mode.hunt;
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
        if (hirameScript == null)
        {
            hirameScript = hirame.GetComponent<HirameMove>();
        }
    }
}
