using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Card;
    public GameObject FirstCard;
    public GameObject SecondCard;
    public Text TimeTxt;
    public Text CountTxt;
    public GameObject endPanel;
    public GameObject MatchTxt;
    public static GameManager I;

    public AudioClip match;
    public AudioClip dismatch;
    public AudioSource audioSource;
    float time = 0.0f;
    int count = 0;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1.0f;
        //카드 리스트 작성
        int[] teams = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        //랜덤하게 섞기 나중에 다른코드로 바꿔보자!
        teams = teams.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
        //카드의 생성은 게임매니저가!
        for (int i = 0;i < 20;i++)
        {
            //반복문 정상 작동 확인! 20장으로 나열하고 싶어서 조건으로 I<20을 달았다.
            GameObject newCard = Instantiate(Card);//카드 생성
            newCard.transform.parent = GameObject.Find("Cards").transform;//생성되는 카드들은 Cards의 Child로 생성된다.

            //카드 위치 잡기
            float x = (i / 5) * 1.2f - 1.8f;
            float y = (i % 5) * 1.2f - 4.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            //이미지 이름을 만들어두고 새 카드 아래 front를 찾아 sprite를 변경 해야한다.
            //Resources폴더에 있는 teamsName 이미지를 가져오자
            string teamName = "team" + teams[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(teamName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //시간의 흐름을 변수 time에 저장
        time += Time.deltaTime;
        //변수 time에 저장된 시간을 소수점 둘째 자리까지 출력
        TimeTxt.text = time.ToString("N2");
        if (time >= 30f)
        {
            Invoke("GameEnd", 0f);
        }
        
    }

    public void isMatched()
    {
        //첫번째 카드로 지목된 Card의 Front가 가지고 있는 스프라이트의 이름을 찾는다.
        string FirstCardImage = FirstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string SecnodCardImage = SecondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        //첫번째 카드와 두번째 카드의 스프라이트 이름이 같은지 다른지 판단
        if(FirstCardImage == SecnodCardImage)
        {
           
            audioSource.PlayOneShot(match);
            VSMTxt();
            FirstCard.GetComponent<card>().destroyCard();
            SecondCard.GetComponent<card>().destroyCard();

            int cardLeft = GameObject.Find("Cards").transform.childCount;
            if (cardLeft == 2)
            {
                GameOver();
            }
        }
        else//매칭에 실패했을 경우
        {
            audioSource.PlayOneShot(dismatch);
            VFMTxt();
            FirstCard.GetComponent<card>().closeCard();
            SecondCard.GetComponent<card>().closeCard();
        }
        //판단후 카드를 다시 뽑을 수 있도록 목록을 초기화
        FirstCard = null;
        SecondCard = null;
        count++;
        OffMtxt();
    }
    void GameOver()
    {
        CountTxt.text = count.ToString();
        endPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    void VSMTxt()//매칭성공했을때 보여주는 MatchTxt
    {
        MatchTxt.SetActive(true);
        MatchTxt.GetComponent<MatchTxt>().SuOnFaOff();
    }
    void VFMTxt()//매칭실패 했을때 보여주는 MatchTxt
    {
        MatchTxt.SetActive(true);
        MatchTxt.GetComponent<MatchTxt>().FaONSuOff(); 
    }
    void OffMtxt()
    {
        Invoke("OffMTxtInvoke", 0.2f);
    }
    
    
    void OffMTxtInvoke()
    {
        MatchTxt.SetActive(false);
    }
}
