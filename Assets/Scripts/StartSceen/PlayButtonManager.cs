using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public Animator animator;
    public GameObject StartScreenCanvas;


    public bool hovering;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        animator.SetBool("Hover", hovering);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    public void OnClickPlay()
    {
        Time.timeScale = 1;
        StartScreenCanvas.SetActive(false);
    }
}
