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
    int LR;//¶‰E‚Ç‚¿‚ç‚É‹È‚ª‚é‚©

    GameObject Hirame;
    HirameMove hirameScript;

    enum Mode
    {
        idle,//“®‚©‚È‚¢
        hunt,//Œx‰ú
        relax//’Êí
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
        #region ’ÊíˆÚ“®
        if (mode == Mode.idle)
        {
            //ˆÚ“®‚µ‚È‚¢
        }
        if (mode == Mode.relax)
        {
            //‘OˆÚ“®
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //‰½•b‚©‚²‚Æ‚Éù‰ñ
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

        #region ’Ç‚¢‚©‚¯ƒ‚[ƒh
        if(mode == Mode.hunt)
        {
            if (hirameScript.GetHideMater() < 0.9f)
            {
                hirameposLocal = transform.InverseTransformPoint(Hirame.transform.position);//ƒqƒ‰ƒ‚ÌˆÊ’u‚ğ‘Š‘ÎÀ•W‚Åæ“¾
                //ƒqƒ‰ƒ‚ª‰E‚É‚¢‚éê‡
                if (hirameposLocal.x > 0)
                {
                    //‰Eù‰ñ
                    transform.Rotate(0, 0, -1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed;
                }
                //ƒqƒ‰ƒ‚ª¶‚É‚¢‚éê‡
                if (hirameposLocal.x < 0)
                {
                    //¶ù‰ñ
                    transform.Rotate(0, 0, 1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed;
                }
                //ƒqƒ‰ƒ‚ª³–Ê
                if (hirameposLocal.x == 0)
                {
                    //“Ëi
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
