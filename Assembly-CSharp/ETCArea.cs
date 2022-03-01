using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02004935 RID: 18741
[Serializable]
public class ETCArea : MonoBehaviour
{
	// Token: 0x0601AF3D RID: 110397 RVA: 0x00849814 File Offset: 0x00847C14
	public ETCArea()
	{
		this.show = true;
	}

	// Token: 0x0601AF3E RID: 110398 RVA: 0x00849823 File Offset: 0x00847C23
	public void Awake()
	{
		base.GetComponent<Image>().enabled = this.show;
	}

	// Token: 0x0601AF3F RID: 110399 RVA: 0x00849838 File Offset: 0x00847C38
	public void ApplyPreset(ETCArea.AreaPreset preset)
	{
		RectTransform component = base.transform.parent.GetComponent<RectTransform>();
		switch (preset)
		{
		case ETCArea.AreaPreset.TopLeft:
			this.rectTransform().anchoredPosition = new Vector2(-component.rect.width / 4f, component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(0, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(1, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(0f, 1f);
			this.rectTransform().anchorMax = new Vector2(0f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f, -this.rectTransform().sizeDelta.y / 2f);
			break;
		case ETCArea.AreaPreset.TopRight:
			this.rectTransform().anchoredPosition = new Vector2(component.rect.width / 4f, component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(0, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(1, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(1f, 1f);
			this.rectTransform().anchorMax = new Vector2(1f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f, -this.rectTransform().sizeDelta.y / 2f);
			break;
		case ETCArea.AreaPreset.BottomLeft:
			this.rectTransform().anchoredPosition = new Vector2(-component.rect.width / 4f, -component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(0, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(1, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(0f, 0f);
			this.rectTransform().anchorMax = new Vector2(0f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f, this.rectTransform().sizeDelta.y / 2f);
			break;
		case ETCArea.AreaPreset.BottomRight:
			this.rectTransform().anchoredPosition = new Vector2(component.rect.width / 4f, -component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(0, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(1, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(1f, 0f);
			this.rectTransform().anchorMax = new Vector2(1f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f, this.rectTransform().sizeDelta.y / 2f);
			break;
		}
	}

	// Token: 0x04012C39 RID: 76857
	public bool show;

	// Token: 0x02004936 RID: 18742
	public enum AreaPreset
	{
		// Token: 0x04012C3B RID: 76859
		Choose,
		// Token: 0x04012C3C RID: 76860
		TopLeft,
		// Token: 0x04012C3D RID: 76861
		TopRight,
		// Token: 0x04012C3E RID: 76862
		BottomLeft,
		// Token: 0x04012C3F RID: 76863
		BottomRight
	}
}
