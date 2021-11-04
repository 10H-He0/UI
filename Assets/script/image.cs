using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class image : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform origin;

    public void OnBeginDrag(PointerEventData eventData)
    {
        origin = transform.parent;
        transform.SetParent(transform.parent.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Item")
        {
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            transform.rotation = eventData.pointerCurrentRaycast.gameObject.transform.rotation;
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "Image")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            transform.rotation = eventData.pointerCurrentRaycast.gameObject.transform.rotation;
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(origin);
            eventData.pointerCurrentRaycast.gameObject.transform.position = origin.position;
            eventData.pointerCurrentRaycast.gameObject.transform.rotation = origin.rotation;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.tag == "j8")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.Find("Content"));
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else
        {
            transform.SetParent(origin);
            transform.position = origin.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
