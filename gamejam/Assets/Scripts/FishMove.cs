using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed;
    public int hp;//�̗�
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
        if(mode == Mode.idle)//�ҋ@���
        {
            //�ړ��Ȃ�
        }
        if (mode == Mode.relax)//��{�̈ړ�
        {
            //�O�ړ�
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            //���b�����Ƃɐ���
            
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
