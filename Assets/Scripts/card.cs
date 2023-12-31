using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public AudioClip flip;
    public AudioSource audioSource;
    public Animator anim;
    public bool flipCount = false;
    SpriteRenderer cardBack;
    // Start is called before the first frame update
    void Start()
    {
        cardBack = transform.Find("Back").gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OepnCard()
    {
        audioSource.PlayOneShot(flip);
        anim.SetBool("isOpen", true);
        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);

        // 카드를 뒤집으면 firstCard와 SecondCard에 나를 넣기
        //첫번째 카드가 공란이면 첫번쨰 카드로 인식됨
        if (GameManager.I.FirstCard == null)
        {
            GameManager.I.FirstCard = gameObject;
        }
        else//첫번째 카드가 있으면 두번째 카드로 인식됨
        {//두 카드가 맞는 카드인지 확인
            GameManager.I.SecondCard = gameObject;
            GameManager.I.isMatched();
        }
        flipCount = true;
        CardBackColorChange();
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

    void CardBackColorChange()
    {
        if (flipCount == true)
        {
            cardBack.color = new Color(0.9f, 0.9f, 0.9f);
        }
    }
}
