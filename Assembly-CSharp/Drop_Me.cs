using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02001AA5 RID: 6821
public class Drop_Me : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06010BC3 RID: 68547 RVA: 0x004BF174 File Offset: 0x004BD574
	public void OnEnable()
	{
		if (this.containerImage != null)
		{
			this.normalColor = this.containerImage.color;
		}
	}

	// Token: 0x06010BC4 RID: 68548 RVA: 0x004BF198 File Offset: 0x004BD598
	public void OnDrop(PointerEventData data)
	{
		if (this.containerImage != null)
		{
			this.containerImage.color = this.normalColor;
		}
		if (this.receivingImage == null)
		{
			return;
		}
		Sprite dropSprite = this.GetDropSprite(data);
		if (dropSprite != null)
		{
			if (this.bAutoReplace)
			{
				this.receivingImage.sprite = dropSprite;
			}
			GameObject gameObject = this.receivingImage.transform.parent.gameObject;
			if (this.ResponseDrop != null)
			{
				this.ResponseDrop(data, gameObject);
			}
		}
	}

	// Token: 0x06010BC5 RID: 68549 RVA: 0x004BF234 File Offset: 0x004BD634
	public void OnPointerEnter(PointerEventData data)
	{
		if (this.containerImage == null)
		{
			return;
		}
		Sprite dropSprite = this.GetDropSprite(data);
		if (dropSprite != null && this.bHighLight)
		{
			this.containerImage.color = this.highlightColor;
		}
	}

	// Token: 0x06010BC6 RID: 68550 RVA: 0x004BF283 File Offset: 0x004BD683
	public void OnPointerExit(PointerEventData data)
	{
		if (this.containerImage == null)
		{
			return;
		}
		this.containerImage.color = this.normalColor;
	}

	// Token: 0x06010BC7 RID: 68551 RVA: 0x004BF2A8 File Offset: 0x004BD6A8
	private Sprite GetDropSprite(PointerEventData data)
	{
		GameObject pointerDrag = data.pointerDrag;
		if (pointerDrag == null)
		{
			return null;
		}
		Drag_Me component = pointerDrag.GetComponent<Drag_Me>();
		if (component == null)
		{
			return null;
		}
		Image component2 = pointerDrag.GetComponent<Image>();
		if (component2 == null)
		{
			return null;
		}
		return component2.sprite;
	}

	// Token: 0x06010BC8 RID: 68552 RVA: 0x004BF2FA File Offset: 0x004BD6FA
	public void SetHighLight(bool bFlag)
	{
		this.bHighLight = bFlag;
	}

	// Token: 0x06010BC9 RID: 68553 RVA: 0x004BF303 File Offset: 0x004BD703
	public void SetAutoReplace(bool bFlag)
	{
		this.bAutoReplace = bFlag;
	}

	// Token: 0x0400AB33 RID: 43827
	public Drop_Me.OnResDrop ResponseDrop;

	// Token: 0x0400AB34 RID: 43828
	public Image containerImage;

	// Token: 0x0400AB35 RID: 43829
	public Image receivingImage;

	// Token: 0x0400AB36 RID: 43830
	private Color normalColor;

	// Token: 0x0400AB37 RID: 43831
	public Color highlightColor = Color.yellow;

	// Token: 0x0400AB38 RID: 43832
	private bool bHighLight = true;

	// Token: 0x0400AB39 RID: 43833
	private bool bAutoReplace = true;

	// Token: 0x0400AB3A RID: 43834
	public int slot = -1;

	// Token: 0x0400AB3B RID: 43835
	public EDropGroup DropGroup;

	// Token: 0x02001AA6 RID: 6822
	// (Invoke) Token: 0x06010BCB RID: 68555
	public delegate void OnResDrop(PointerEventData DragData, GameObject BeDropedImgParent);
}
