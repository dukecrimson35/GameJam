using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HirameMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;//�ړ����x
    public float rotateSpeed = 0.5f;//���񑬓x
    public int hp;//�̗�
    public float bounding;//�͂������
    bool atFlag;//�U���\�t���O
    GameObject foodFish;//�U���Ώ�
    public bool shiFlag = false;

    int fishcount;//�H�ׂ�����

    public float hideMater;//�B��Ă�w��
    float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region �ړ�
        if (Input.GetKey(KeyCode.LeftArrow))//��
        {
            transform.Rotate(0, 0, 1*rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            time += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))//�E
        {
            transform.Rotate(0, 0, -1 * rotateSpeed);
            transform.position += transform.up * 1f * Time.deltaTime * moveSpeed;
            time += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))//�O
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

        #region �U��
        if (atFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
        #endregion

        #region �����΂�
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            hideMater += 0.2f;
        }
        if(hideMater > 1)
        {
            hideMater = 1;
            Debug.Log("�B�ꂽ");
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

        #region ���S
        if(hp <= 0)
        {
            shiFlag = true;//���S
        }
        #endregion

        #region �N���A
        if(GameObject.FindWithTag("Fish") == false)
        {
            SceneManager.LoadScene("EndingScene");
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 derection;//�͂������
        if (other.gameObject.tag == "Shark")//�T���Ɠ���������
        {
            derection = (transform.position - other.transform.position)*bounding;
            hp -= 1;//�_���[�W
            transform.position = new Vector3(derection.x + transform.position.x, derection.y + transform.position.y, transform.position.z);//�͂������
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Fish")//���ƐڐG���Ă�Ƃ�
        {
            atFlag = true;
            foodFish = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fish")//���Ɨ��ꂽ�Ƃ�
        {
            atFlag = false;
        }
    }

    void Attack()//�U��
    {
        FishMove fish = foodFish.GetComponent<FishMove>();
        fish.Damage(100);
        //Debug.Log("a");
    }

    public void AteIt()//���ׂ��I
    {
        fishcount += 1;
        Debug.Log("�H�ׂ�����" + fishcount);
    }

    public float GetHideMater()
    {
        return hideMater;
    }
}
