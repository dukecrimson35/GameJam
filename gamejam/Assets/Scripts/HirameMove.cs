using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HirameMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;//移動速度
    public float rotateSpeed = 0.5f;//旋回速度
    public int hp;//体力
    public float bounding;//はじかれ力
    bool atFlag;//攻撃可能フラグ
    GameObject foodFish;//攻撃対象
    public bool shiFlag = false;

    int fishcount;//食べたかず

    public float hideMater;//隠れてる指数
    float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region 移動
        if (Input.GetKey(KeyCode.LeftArrow))//左
        {
            transform.Rotate(0, 0, 1*rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            time += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))//右
        {
            transform.Rotate(0, 0, -1 * rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            time += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))//前
        {
            if (Input.GetKey(KeyCode.RightArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true)
            {
                transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
                time += Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.UpArrow)==false&&Input.GetKey(KeyCode.RightArrow)==false&&Input.GetKey(KeyCode.LeftArrow)==false)
        {
            time = 0;
        }
        #endregion

        #region 攻撃
        if (atFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
        #endregion

        #region じたばた
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            hideMater += 0.2f;
        }
        if(hideMater > 1)
        {
            hideMater = 1;
            Debug.Log("隠れた");
        }
        if(hideMater < 0)
        {
            hideMater = 0;
        }
        if(time >= 0.5f)
        {
            hideMater -= 0.01f;
        }
        #endregion

        #region 死亡
        if(hp <= 0)
        {
            shiFlag = true;//死亡
        }
        #endregion

        #region クリア
        if(GameObject.FindWithTag("Fish") == false)
        {
            SceneManager.LoadScene("EndingScene");
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 derection;//はじかれ先
        if (other.gameObject.tag == "Shark")//サメと当たった時
        {
            derection = (transform.position - other.transform.position)*bounding;
            hp -= 1;//ダメージ
            transform.position = new Vector3(derection.x + transform.position.x, derection.y + transform.position.y, transform.position.z);//はじかれる
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Fish")//魚と接触してるとき
        {
            atFlag = true;
            foodFish = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fish")//魚と離れたとき
        {
            atFlag = false;
        }
    }

    void Attack()//攻撃
    {
        FishMove fish = foodFish.GetComponent<FishMove>();
        fish.Damage(100);
        //Debug.Log("a");
    }

    public void AteIt()//たべた！
    {
        fishcount += 1;
        Debug.Log("食べた数は" + fishcount);
    }

    public float GetHideMater()
    {
        return hideMater;
    }
}
