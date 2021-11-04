using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class img : MonoBehaviour
{
    public GameObject[] IMG;
    public float time = 2;
    private int Num;
    // Start is called before the first frame update
    void Start()
    {
        IMG[0].SetActive(true);
        Num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            IMG[Num].SetActive(false);
            Num++;
            if (Num > 2) Num = 0;
            IMG[Num].SetActive(true);
            time = 2;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    public void to_fir()
    {
        IMG[Num].SetActive(false);
        Num = 0;
        IMG[Num].SetActive(true);
        time = 2;
    }

    public void to_sec()
    {
        IMG[Num].SetActive(false);
        Num = 1;
        IMG[Num].SetActive(true);
        time = 2;
    }

    public void to_thi()
    {
        IMG[Num].SetActive(false);
        Num = 2;
        IMG[Num].SetActive(true);
        time = 2;
    }

    public void next()
    {
        IMG[Num].SetActive(false);
        Num++;
        if (Num > 2) Num = 0;
        IMG[Num].SetActive(true);
        time = 2;
    }

    public void last()
    {
        IMG[Num].SetActive(false);
        Num--;
        if (Num < 0) Num = 2;
        IMG[Num].SetActive(true);
        time = 2;
    }
}
