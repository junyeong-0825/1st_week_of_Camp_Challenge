using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTxt : MonoBehaviour
{
    public GameObject failTxt;
    public GameObject successTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SuOnFaOff()
    {
        failTxt.SetActive(false);
        successTxt.SetActive(true);
    }
    public void FaONSuOff()
    {
        failTxt.SetActive(true);
        successTxt.SetActive(false);
    }
}
