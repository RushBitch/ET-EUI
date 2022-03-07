using System;
using ET;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchEventComponent : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<PointerEventData> PointerEnterHandler { get; set; }
    public Action<PointerEventData> PointerExitHandler { get; set; }
    public Action<PointerEventData> PointerDownHandler { get; set; }
    public Action<PointerEventData> PointerUpHandler { get; set; }
    public Action<PointerEventData> PointerClickHandler { get; set; }
    public Action<PointerEventData> BeginDragHandler { get; set; }
    public Action<PointerEventData> DragHandler { get; set; }
    public Action<PointerEventData> EndDragHandler { get; set; }
    /// <summary>
    /// 当鼠标滑入控件的范围
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("鼠标划入");
        if (PointerEnterHandler != null)
            PointerEnterHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当鼠标离开控件的范围
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("鼠标离开");
        if (PointerExitHandler != null)
            PointerExitHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当鼠标在控件范围内按下
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("鼠标按下");
        if (PointerDownHandler != null)
            PointerDownHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当鼠标在控件范围内抬起
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("鼠标抬起");
        if (PointerUpHandler != null)
            PointerUpHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当鼠标在控件范围内点击
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("鼠标点击");
        if (PointerClickHandler != null)
            PointerClickHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当鼠标开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("开始拖拽");
        if (BeginDragHandler != null)
            BeginDragHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当鼠标拖拽过程中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("拖拽中");
        if (DragHandler != null)
            DragHandler.Invoke(eventData);
    }

    /// <summary>
    /// 当拖拽完成
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("拖拽完成");
        if (EndDragHandler != null)
            EndDragHandler.Invoke(eventData);
    }
}

