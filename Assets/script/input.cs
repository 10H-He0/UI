using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input : MonoBehaviour
{
    public GameObject inputtext;

    // Start is called before the first frame update
    void Start()
    {
        inputtext.GetComponent<InputField>().text = "可以输入了哟~";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
