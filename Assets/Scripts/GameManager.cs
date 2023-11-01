using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TimeTxt;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
