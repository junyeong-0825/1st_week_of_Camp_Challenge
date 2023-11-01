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
        //ī�� ����Ʈ �ۼ�
        int[] teams = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
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

            Debug.Log(teams[i]);
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
