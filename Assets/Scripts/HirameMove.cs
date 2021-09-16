using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HirameMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;//移動速度
    public float rotateSpeed = 0.5f;//旋回速度
    bool atFlag;//攻撃フラグ

    bool hideFlag = false;//隠れているかの状態判定

    // Start is called before the first frame update
    void Start()
    {
        hideFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region 移動
        if (Input.GetKey(KeyCode.LeftArrow))//左
        {
            transform.Rotate(0, 0, 1*rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))//右
        {
            transform.Rotate(0, 0, -1 * rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))//前
        {
            if (Input.GetKey(KeyCode.RightArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true)
            {
                transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            }
        }
        #endregion

        #region 攻撃
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        #endregion

        #region 隠れる
        if(Input.GetKeyDown(KeyCode.C))
        {
            
        }
        #endregion
    }


    private void OnCollisionEnter(Collision collision)
    {
        //ダメージ

        //捕食
    }

    void Attack()//攻撃
    {

    }

    void Hide()
    {
        hideFlag = true;
    }
}
