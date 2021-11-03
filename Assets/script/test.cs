using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler,IScrollHandler
{
    public RectTransform canvas;
    private RectTransform imgRect;
    Vector2 offset = new Vector3();

    public Slider red;
    public Slider green;
    public Slider blue;
    private Image mater;

    // Start is called before the first frame update
    void Start()
    {
        imgRect = transform.GetComponent<RectTransform>();
        mater = GetComponent<Image>();
        red.value = green.value = blue.value = 1;
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.localScale += Vector3.one * 0.1f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.localScale += Vector3.one * -0.1f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 mousedown = eventData.position;
        Vector2 mouseuguipos = new Vector2();

        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mousedown, eventData.enterEventCamera, out mouseuguipos);
        if (isRect)
        {
            offset = imgRect.anchoredPosition - mouseuguipos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousrdrag = eventData.position;
        Vector2 uguipos = new Vector2();

        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mousrdrag, eventData.enterEventCamera, out uguipos);
        if (isRect)
        {
            imgRect.anchoredPosition = offset + uguipos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        offset = Vector2.zero;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        offset = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        mater.color = new Color(red.value, green.value, blue.value);
    }
}
