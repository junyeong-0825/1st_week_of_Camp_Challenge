using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OepnCard()
    {
        anim.SetBool("isOpen", true);
        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);

        // ī�带 �������� firstCard�� SecondCard�� ���� �ֱ�
        //ù��° ī�尡 �����̸� ù���� ī��� �νĵ�
        if (GameManager.I.FirstCard == null)
        {
            GameManager.I.FirstCard = gameObject;
        }
        else//ù��° ī�尡 ������ �ι�° ī��� �νĵ�
        {//�� ī�尡 �´� ī������ Ȯ��
            GameManager.I.SecondCard = gameObject;
            GameManager.I.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 0.4f);
    }
    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("Back").gameObject.SetActive(true);
        transform.Find("Front").gameObject.SetActive(false);
    }
}
