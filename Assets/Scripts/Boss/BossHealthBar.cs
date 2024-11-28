using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public RectTransform healthBarRect; // Tham chiếu tới RectTransform của thanh máu
    public Vector3 Offset; // Độ lệch so với vị trí của boss
    public Image fillBar; // Thanh máu
    public Transform bossTransform; // Transform của boss

    public void UpdateBar(int currenValue, int maxValue)
    {
        // Cập nhật lượng máu bằng cách thay đổi fillAmount của Image
        if (fillBar != null)
        {
            fillBar.fillAmount = (float)currenValue / (float)maxValue;
        }
    }

    private void Update()
    {
        // Di chuyển thanh máu theo vị trí của boss
        if (bossTransform != null && healthBarRect != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(bossTransform.position + Offset);
            healthBarRect.position = screenPosition;
        }
    }
}
