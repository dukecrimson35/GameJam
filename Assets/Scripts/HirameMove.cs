using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HirameMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;//�ړ����x
    public float rotateSpeed = 0.5f;//���񑬓x
    bool atFlag;//�U���t���O

    bool hideFlag = false;//�B��Ă��邩�̏�Ԕ���

    // Start is called before the first frame update
    void Start()
    {
        hideFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region �ړ�
        if (Input.GetKey(KeyCode.LeftArrow))//��
        {
            transform.Rotate(0, 0, 1*rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))//�E
        {
            transform.Rotate(0, 0, -1 * rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))//�O
        {
            if (Input.GetKey(KeyCode.RightArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true)
            {
                transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            }
        }
        #endregion

        #region �U��
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        #endregion

        #region �B���
        if(Input.GetKeyDown(KeyCode.C))
        {
            
        }
        #endregion
    }


    private void OnCollisionEnter(Collision collision)
    {
        //�_���[�W

        //�ߐH
    }

    void Attack()//�U��
    {

    }

    void Hide()
    {
        hideFlag = true;
    }
}
