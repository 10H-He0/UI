using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject obj;
    public GameObject butt;

    public GameObject tex;
    public GameObject tex_bar;

    public GameObject img;
    public GameObject img_bar;

    public GameObject i_bar;
    public GameObject io;

    public GameObject sel_cir;
    public GameObject sel_cir_roll;

    public GameObject pic;
    public GameObject butto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void act()
    {
        if (obj.activeInHierarchy)
            obj.SetActive(false);
        else obj.SetActive(true);
        if (butt.activeInHierarchy)
            butt.SetActive(false);
        else butt.SetActive(true);
        if (i_bar.activeInHierarchy)
            i_bar.SetActive(false);
        if (io.activeInHierarchy)
            io.SetActive(false);
    }

    public void act_tex()
    {
        if (tex.activeInHierarchy)
            tex.SetActive(false);
        else tex.SetActive(true);
        if (tex_bar.activeInHierarchy)
            tex_bar.SetActive(false);
        else tex_bar.SetActive(true);
    }

    public void act_img()
    {
        if (img.activeInHierarchy)
            img.SetActive(false);
        else img.SetActive(true);
        if (img_bar.activeInHierarchy)
            img_bar.SetActive(false);
        else img_bar.SetActive(true);
    }

    public void act_but()
    {
        i_bar.SetActive(true);
        obj.GetComponent<test>().enabled = true;
        io.SetActive(true);
    }

    public void act_sel_ci()
    {
        if (sel_cir.activeInHierarchy)
            sel_cir.SetActive(false);
        else sel_cir.SetActive(true);
        if (sel_cir_roll.activeInHierarchy)
            sel_cir_roll.SetActive(false);
        else sel_cir_roll.SetActive(true);
    }

    public void act_sel_pic()
    {
        if (pic.activeInHierarchy)
            pic.SetActive(false);
        else pic.SetActive(true);
        if (butto.activeInHierarchy)
            butto.SetActive(false);
        else butto.SetActive(true);
    }
}
