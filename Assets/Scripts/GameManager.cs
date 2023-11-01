using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Card;
    public Text TimeTxt;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //카드 리스트 작성
        int[] teams = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
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

            Debug.Log(teams[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //시간의 흐름을 변수 time에 저장
        time += Time.deltaTime;
        //변수 time에 저장된 시간을 소수점 둘째 자리까지 출력
        TimeTxt.text = time.ToString("N2");
    }
}
