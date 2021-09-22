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
    int LR;//���E�ǂ���ɋȂ��邩

    GameObject Hirame;
    HirameMove hirameScript;

    enum Mode
    {
        idle,//�����Ȃ�
        hunt,//�x��
        relax//�ʏ�
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
        #region �ʏ�ړ�
        if (mode == Mode.idle)
        {
            //�ړ����Ȃ�
        }
        if (mode == Mode.relax)
        {
            //�O�ړ�
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //���b�����Ƃɐ���
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

        #region �ǂ��������[�h
        if(mode == Mode.hunt)
        {
            if (hirameScript.GetHideMater() < 0.9f)
            {
                hirameposLocal = transform.InverseTransformPoint(Hirame.transform.position);//�q�����̈ʒu�𑊑΍��W�Ŏ擾
                //�q�������E�ɂ���ꍇ
                if (hirameposLocal.x > 0)
                {
                    //�E����
                    transform.Rotate(0, 0, -1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed;
                }
                //�q���������ɂ���ꍇ
                if (hirameposLocal.x < 0)
                {
                    //������
                    transform.Rotate(0, 0, 1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * huntSpeed;
                }
                //�q����������
                if (hirameposLocal.x == 0)
                {
                    //�ːi
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
