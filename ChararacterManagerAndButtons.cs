using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChararacterManagerAndButtons : MonoBehaviour
{
    private Animator anim;
    private bool _walking;
    
    private Button myButton;
    private Action myButtonAction;

    private event Action OnButtonClick;

    IEnumerator Start()
    {
        
        Button myButton = GameObject.Find("MYButton").GetComponent<Button>();

        // Action'ı belirli bir metot ile ilişkilendirin
        //myButtonAction = CGG_walk;

        // Buton tıklama olayına dinleyici ekleyin
        //myButton.onClick.AddListener(() => myButtonAction());
        
        //UnityAction actionDelegate = new UnityAction(myButtonAction);
        //myButton.onClick.AddListener(actionDelegate);

        OnButtonClick += CGG_walk;
        myButton.onClick.AddListener(InvokeButtonClickEvent);
        
        
        //myButton = GameObject.Find("MYButton").GetComponent<Button>();
        //myButton.onClick.AddListener(CGG_walk);
        anim = GetComponent<Animator>();
        _walking = anim.GetBool("walking");
        yield return null;
    }

    public void CGG_walk()
    {
        StartCoroutine(_Walking());
    }

    IEnumerator _Walking()
    {
        _walking = true;
        anim.SetBool("walking", _walking);
        yield return new WaitForSeconds(0.1f);
        _walking = false;
        anim.SetBool("walking", _walking);
    }

    protected virtual void InvokeButtonClickEvent()
    {
        OnButtonClick?.Invoke();
    }
}
