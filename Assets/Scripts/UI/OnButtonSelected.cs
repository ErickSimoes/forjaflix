using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class OnButtonSelected : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private float animationDuration = 0.075f;
    [SerializeField] private Shadow UIShadow;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private Vector2 defaultShadowDistance = new Vector2(15, -15);

    void Awake()
    {
        UIText = GetComponentInChildren<TextMeshProUGUI>();
        UIShadow = GetComponent<Shadow>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        transform.DOScale(1.075f, animationDuration).SetEase(Ease.InOutQuad);

        UIText.DOColor(Color.white, animationDuration);

        DOTween.To(() => UIShadow.effectDistance, x => UIShadow.effectDistance = x, defaultShadowDistance, animationDuration);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        transform.DOScale(1f, animationDuration);

        UIText.DOColor(Color.black, animationDuration);

        DOTween.To(() => UIShadow.effectDistance, x => UIShadow.effectDistance = x, Vector2.zero, animationDuration);
    }

}
