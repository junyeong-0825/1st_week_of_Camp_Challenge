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
        //ī���� ������ ���ӸŴ�����!
        for (int i = 0;i < 20;i++)
        {
            //�ݺ��� ���� �۵� Ȯ��! 20������ �����ϰ� �; �������� I<20�� �޾Ҵ�.
            GameObject newCard = Instantiate(Card);//ī�� ����
            newCard.transform.parent = GameObject.Find("Cards").transform;//�����Ǵ� ī����� Cards�� Child�� �����ȴ�.






        }
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
