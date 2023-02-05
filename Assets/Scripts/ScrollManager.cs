using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public RectTransform bgPivot;

    public RectTransform from;
    public RectTransform to;

    public SphereManager sphere;

    Vector2 newPos;

    public void MoveLeft(RectTransform panel)
    {
        if (bgPivot.anchoredPosition.x <= -1405)
        {
            GameManager.instance.SetGameOverScreen();
            GameManager.instance.isGameOver = true;
        }
        else
        {
           StartCoroutine(Move(panel, new Vector2(newPos.x - 200, 0)));
        }

        //Debug.Log(bgPivot.anchoredPosition.x);
    }

    IEnumerator Move(RectTransform rt, Vector2 targetPos)
    {
        float step = 0;
        while (step < 1)
        {
            rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
            rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        newPos = targetPos;

    }



}
