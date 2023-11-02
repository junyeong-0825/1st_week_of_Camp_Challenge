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
        //ī�� ����Ʈ �ۼ�
        int[] teams = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        //�����ϰ� ���� ���߿� �ٸ��ڵ�� �ٲ㺸��!
        teams = teams.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
        //ī���� ������ ���ӸŴ�����!
        for (int i = 0;i < 20;i++)
        {
            //�ݺ��� ���� �۵� Ȯ��! 20������ �����ϰ� �; �������� I<20�� �޾Ҵ�.
            GameObject newCard = Instantiate(Card);//ī�� ����
            newCard.transform.parent = GameObject.Find("Cards").transform;//�����Ǵ� ī����� Cards�� Child�� �����ȴ�.

            //ī�� ��ġ ���
            float x = (i / 5) * 1.2f - 1.8f;
            float y = (i % 5) * 1.2f - 4.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            //�̹��� �̸��� �����ΰ� �� ī�� �Ʒ� front�� ã�� sprite�� ���� �ؾ��Ѵ�.
            //Resources������ �ִ� teamsName �̹����� ��������
            string teamName = "team" + teams[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(teamName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�ð��� �帧�� ���� time�� ����
        time += Time.deltaTime;
        //���� time�� ����� �ð��� �Ҽ��� ��° �ڸ����� ���
        TimeTxt.text = time.ToString("N2");
        if (time >= 30f)
        {
            Invoke("GameEnd", 0f);
        }
        
    }

    public void isMatched()
    {
        //ù��° ī��� ����� Card�� Front�� ������ �ִ� ��������Ʈ�� �̸��� ã�´�.
        string FirstCardImage = FirstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string SecnodCardImage = SecondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        //ù��° ī��� �ι�° ī���� ��������Ʈ �̸��� ������ �ٸ��� �Ǵ�
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
        else//��Ī�� �������� ���
        {
            audioSource.PlayOneShot(dismatch);
            VFMTxt();
            FirstCard.GetComponent<card>().closeCard();
            SecondCard.GetComponent<card>().closeCard();
        }
        //�Ǵ��� ī�带 �ٽ� ���� �� �ֵ��� ����� �ʱ�ȭ
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
    void VSMTxt()//��Ī���������� �����ִ� MatchTxt
    {
        MatchTxt.SetActive(true);
        MatchTxt.GetComponent<MatchTxt>().SuOnFaOff();
    }
    void VFMTxt()//��Ī���� ������ �����ִ� MatchTxt
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
