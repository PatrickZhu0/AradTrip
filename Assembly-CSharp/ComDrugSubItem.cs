using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x02000EBD RID: 3773
public class ComDrugSubItem : MonoBehaviour, IDropHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06009491 RID: 38033 RVA: 0x001BDD99 File Offset: 0x001BC199
	public void OnDrop(PointerEventData data)
	{
		if (null == this.mainItem)
		{
			return;
		}
		if (data.pointerDrag == this.mainItem.gameObject)
		{
			this.OnEffect();
		}
	}

	// Token: 0x06009492 RID: 38034 RVA: 0x001BDDCE File Offset: 0x001BC1CE
	public bool isSelect()
	{
		return this.mState == ComDrugSubItem.eState.Select;
	}

	// Token: 0x06009493 RID: 38035 RVA: 0x001BDDD9 File Offset: 0x001BC1D9
	public void OnEffect()
	{
		if (this.isSelect())
		{
			this._onRealClick();
			this.UnSelect();
		}
	}

	// Token: 0x06009494 RID: 38036 RVA: 0x001BDDF2 File Offset: 0x001BC1F2
	public void Select()
	{
		if (this.mState == ComDrugSubItem.eState.Select)
		{
			return;
		}
		this.mState = ComDrugSubItem.eState.Select;
		this.onSelect.Invoke();
		this.mainItem.Mark();
	}

	// Token: 0x06009495 RID: 38037 RVA: 0x001BDE1E File Offset: 0x001BC21E
	public void OnPointerUp(PointerEventData data)
	{
		this.mainItem.UnMark();
	}

	// Token: 0x06009496 RID: 38038 RVA: 0x001BDE2B File Offset: 0x001BC22B
	private void _onRealClick()
	{
		if (null == this.mainItem)
		{
			return;
		}
		this.onClick.Invoke();
		this.mainItem.Hidden();
	}

	// Token: 0x06009497 RID: 38039 RVA: 0x001BDE55 File Offset: 0x001BC255
	public void UnSelect()
	{
		if (this.mState == ComDrugSubItem.eState.UnSelect)
		{
			return;
		}
		this.mState = ComDrugSubItem.eState.UnSelect;
		this.onUnSelect.Invoke();
		this.mainItem.UnMark();
	}

	// Token: 0x06009498 RID: 38040 RVA: 0x001BDE80 File Offset: 0x001BC280
	public void Show(bool enable)
	{
		if (null != base.gameObject)
		{
			base.gameObject.SetActive(enable);
		}
	}

	// Token: 0x04004B60 RID: 19296
	public ComDrugMain mainItem;

	// Token: 0x04004B61 RID: 19297
	public UnityEvent onClick = new UnityEvent();

	// Token: 0x04004B62 RID: 19298
	public UnityEvent onSelect = new UnityEvent();

	// Token: 0x04004B63 RID: 19299
	public UnityEvent onUnSelect = new UnityEvent();

	// Token: 0x04004B64 RID: 19300
	private ComDrugSubItem.eState mState;

	// Token: 0x02000EBE RID: 3774
	private enum eState
	{
		// Token: 0x04004B66 RID: 19302
		UnSelect,
		// Token: 0x04004B67 RID: 19303
		Select
	}
}
