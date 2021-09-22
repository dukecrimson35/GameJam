using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float runSpeed;
    public int hp;//�̗�
    int turnTime = 1;
    float timecount;
    bool rotateflag;
    int LR;//���E�ǂ���ɋȂ��邩
    GameObject Hirame;

    enum Mode 
    { 
        idle,//�����Ȃ�
        careful,//�x��
        relax//�ʏ�
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
        if(mode == Mode.idle)//�ҋ@���
        {
            //�ړ��Ȃ�
        }
        if (mode == Mode.relax)//��{�̈ړ�
        {
            //�O�ړ�
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //���b�����Ƃɐ���
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
        if(mode == Mode.careful)//�v���C���[�ɋC�Â����Ƃ�
        {
            if (hirameScript.GetHideMater() < 0.9f)
            {
                //������悤�Ɉړ�
                hirameposLocal = transform.InverseTransformPoint(Hirame.transform.position);//�q�����̈ʒu�𑊑΍��W�Ŏ擾
                                                                                            //�q�������E�ɂ���ꍇ
                if (hirameposLocal.x > 0)
                {
                    //������
                    transform.Rotate(0, 0, 1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * runSpeed;
                }
                //�q���������ɂ���ꍇ
                if (hirameposLocal.x < 0)
                {
                    //�E����
                    transform.Rotate(0, 0, -1 * rotateSpeed);
                    transform.position += transform.up * 1f * Time.deltaTime * runSpeed;
                }
                //�q����������
                if (hirameposLocal.x == 0)
                {
                    //�ːi
                    transform.position += transform.up * 1f * Time.deltaTime * runSpeed * 1.5f;
                }
            }
            if(hirameScript.GetHideMater() >= 0.9f)
            {
                mode = Mode.relax;
            }
        }

        #region ���ŏ���
        if(hp <= 0)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
        #endregion
    }

    public void Damage(int damage)//�U�����ꂽ
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
