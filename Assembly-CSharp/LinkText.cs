using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FB1 RID: 4017
public class LinkText : MonoBehaviour
{
	// Token: 0x06009AB9 RID: 39609 RVA: 0x001DEA89 File Offset: 0x001DCE89
	private void Awake()
	{
		this.linkText = base.transform.Find("Text").GetComponent<Text>();
	}

	// Token: 0x06009ABA RID: 39610 RVA: 0x001DEAA6 File Offset: 0x001DCEA6
	private void Start()
	{
		this.CreateLink(this.linkText);
	}

	// Token: 0x06009ABB RID: 39611 RVA: 0x001DEAB4 File Offset: 0x001DCEB4
	public void CreateLink(Text text)
	{
		if (text == null)
		{
			return;
		}
		Text text2 = Object.Instantiate<Text>(text);
		text2.name = "Underline";
		text2.transform.SetParent(text.transform);
		RectTransform rectTransform = text2.rectTransform;
		rectTransform.localScale = new Vector3(1f, 1f, 1f);
		rectTransform.anchoredPosition3D = Vector3.zero;
		rectTransform.offsetMax = Vector2.zero;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.anchorMin = Vector2.zero;
		text2.text = "_";
		float preferredWidth = text2.preferredWidth;
		text2.alignment = 7;
		text2.raycastTarget = false;
		float preferredWidth2 = text.preferredWidth;
		int num = (int)Mathf.Round(preferredWidth2 / preferredWidth);
		for (int i = 1; i < num; i++)
		{
			Text text3 = text2;
			text3.text += "_";
		}
	}

	// Token: 0x04005047 RID: 20551
	private Text linkText;
}
