using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public int hp;//�̗�
    int turnTime = 3;
    float timecount;
    bool rotateflag;
    int LR;//���E�ǂ���ɋȂ��邩
    enum Mode 
    { 
        idle,//�����Ȃ�
        careful,//�x��
        relax//�ʏ�
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
        if(mode == Mode.careful)//�v���C���[�ɋC�Â����Ƃ�
        {
            //������悤�Ɉړ�
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
}
