using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

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

    // IO流加载本地外部图片
    public void Load()
    {
        FileStream fileStream = new FileStream("D:\\memo\\test.jpg", FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);

        byte[] bytes = new byte[fileStream.Length];

        fileStream.Read(bytes, 0, (int)fileStream.Length);

        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        int width = 200;
        int heigth = 200;
        Texture2D texture = new Texture2D(width, heigth);
        texture.LoadImage(bytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        mater.sprite = sprite;
    }
    // end

    //实现鼠标滚轮改变图片大小
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
    // end

    //使用鼠标拖动图片
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
    //end

    // Update is called once per frame
    void Update()
    {
        mater.color = new Color(red.value, green.value, blue.value);
    }
}
