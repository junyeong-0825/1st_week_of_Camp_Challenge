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
        //�ð��� �帧�� ���� time�� ����
        time += Time.deltaTime;
        //���� time�� ����� �ð��� �Ҽ��� ��° �ڸ����� ���
        TimeTxt.text = time.ToString("N2");
    }
}
