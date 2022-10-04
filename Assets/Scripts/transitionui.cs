using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class transitionui : MonoBehaviour
{
    public Image[] alltarget;

    void Start()
    {
        StartCoroutine(AnimateMainUI());
    }

    IEnumerator AnimateMainUI() 
    {
        for (int i = 0; i < alltarget.Length; i++) 
        {
            if (i != 0) 
            {
                yield return new WaitForSeconds(0.25f);
            }
            alltarget[i].GetComponentInParent<CanvasGroup>().DOFade(1, 0.25f);
            alltarget[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
        }
    }






}
