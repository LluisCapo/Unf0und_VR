using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MCurvedCanvas : MonoBehaviour
{
    public float curveRadius = 100f;

    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();

        float width = rt.rect.width;
        float height = rt.rect.height;
        float curveX = width / 2 + curveRadius;
        float curveY = height / 2 + curveRadius;
        float offsetX = -width / 2 - curveRadius;
        float offsetY = -height / 2 - curveRadius;

        Vector3[] newCorners = new Vector3[4];
        rt.GetWorldCorners(newCorners);

        for (int i = 0; i < 4; i++)
        {
            Vector3 corner = newCorners[i];
            float distX = Mathf.Abs(corner.x - curveX);
            float distY = Mathf.Abs(corner.y - curveY);
            if (distX < curveRadius && distY < curveRadius)
            {
                float factorX = Mathf.Sqrt(curveRadius * curveRadius - distX * distX);
                float factorY = Mathf.Sqrt(curveRadius * curveRadius - distY * distY);
                if (corner.x < curveX) factorX = -factorX;
                if (corner.y < curveY) factorY = -factorY;
                corner.x += factorX;
                corner.y += factorY;
            }
            newCorners[i] = corner;
        }

        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, newCorners[0].x, width);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, newCorners[0].y, height);

        rt.anchoredPosition = new Vector2(-curveRadius, -curveRadius);
        rt.sizeDelta = new Vector2(width + curveRadius * 2, height + curveRadius * 2);

        rt.GetWorldCorners(newCorners);
    }
}
    //[SerializeField]
    //private float curveRadius = 500f;

    //private RectTransform rectTransform;

    //void Start()
    //{
    //    rectTransform = GetComponent<RectTransform>();
    //}

    //void Update()
    //{
    //    float halfWidth = rectTransform.rect.width / 2f;
    //    float halfHeight = rectTransform.rect.height / 2f;
    //    float radius = Mathf.Max(halfWidth, halfHeight) + curveRadius;

    //    for (int i = 0; i < rectTransform.childCount; i++)
    //    {
    //        Transform child = rectTransform.GetChild(i);
    //        Vector3 position = child.localPosition;

    //        float angle = Mathf.Atan2(position.y, position.x);
    //        float distance = Mathf.Sqrt((position.x * position.x) + (position.y * position.y));

    //        distance = (radius * Mathf.Sin(angle)) + curveRadius;
    //        position.x = distance * Mathf.Cos(angle);
    //        position.y = distance * Mathf.Sin(angle);

    //        child.localPosition = position;
    //    }
    //}