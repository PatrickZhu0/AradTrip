using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x02000EBB RID: 3771
public class ComDrugMain : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06009487 RID: 38023 RVA: 0x001BDB90 File Offset: 0x001BBF90
	private void Awake()
	{
		this._updateSubDrugStatus();
	}

	// Token: 0x06009488 RID: 38024 RVA: 0x001BDB98 File Offset: 0x001BBF98
	private void _updateSubDrugStatus()
	{
		for (int i = 0; i < this.mSubDrugs.Length; i++)
		{
			if (null != this.mSubDrugs[i])
			{
				this.mSubDrugs[i].Show(ComDrugMain.eState.onOpen == this.mState);
			}
		}
	}

	// Token: 0x06009489 RID: 38025 RVA: 0x001BDBE8 File Offset: 0x001BBFE8
	private void _changeState()
	{
		ComDrugMain.eState eState = this.mState;
		if (eState != ComDrugMain.eState.onClose)
		{
			if (eState == ComDrugMain.eState.onOpen)
			{
				this.mState = ComDrugMain.eState.onClose;
				this.mIsMarkd = false;
			}
		}
		else
		{
			this.mState = ComDrugMain.eState.onOpen;
		}
	}

	// Token: 0x0600948A RID: 38026 RVA: 0x001BDC2D File Offset: 0x001BC02D
	public void Mark()
	{
		this.mIsMarkd = true;
	}

	// Token: 0x0600948B RID: 38027 RVA: 0x001BDC36 File Offset: 0x001BC036
	public void UnMark()
	{
		this.mIsMarkd = false;
	}

	// Token: 0x0600948C RID: 38028 RVA: 0x001BDC3F File Offset: 0x001BC03F
	public void Hidden()
	{
		this.mState = ComDrugMain.eState.onClose;
		this._updateSubDrugStatus();
	}

	// Token: 0x0600948D RID: 38029 RVA: 0x001BDC4E File Offset: 0x001BC04E
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.onClick != null)
		{
			this.onClick.Invoke();
		}
		this._changeState();
		this._updateSubDrugStatus();
	}

	// Token: 0x0600948E RID: 38030 RVA: 0x001BDC74 File Offset: 0x001BC074
	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.pointerEnter != null && eventData.pointerEnter != base.gameObject)
		{
			ComDrugSubItem componentInParent = eventData.pointerEnter.GetComponentInParent<ComDrugSubItem>();
			for (int i = 0; i < this.mSubDrugs.Length; i++)
			{
				ComDrugSubItem comDrugSubItem = this.mSubDrugs[i];
				if (componentInParent == comDrugSubItem)
				{
					comDrugSubItem.Select();
				}
				else
				{
					comDrugSubItem.UnSelect();
				}
			}
		}
		else
		{
			for (int j = 0; j < this.mSubDrugs.Length; j++)
			{
				ComDrugSubItem comDrugSubItem2 = this.mSubDrugs[j];
				comDrugSubItem2.UnSelect();
			}
		}
	}

	// Token: 0x0600948F RID: 38031 RVA: 0x001BDD24 File Offset: 0x001BC124
	public void OnPointerUp(PointerEventData eventData)
	{
		this.Hidden();
		for (int i = 0; i < this.mSubDrugs.Length; i++)
		{
			ComDrugSubItem comDrugSubItem = this.mSubDrugs[i];
			if (comDrugSubItem.isSelect())
			{
				comDrugSubItem.OnEffect();
			}
			comDrugSubItem.UnSelect();
		}
	}

	// Token: 0x04004B59 RID: 19289
	public ComDrugSubItem[] mSubDrugs = new ComDrugSubItem[0];

	// Token: 0x04004B5A RID: 19290
	public UnityEvent onClick = new UnityEvent();

	// Token: 0x04004B5B RID: 19291
	private ComDrugMain.eState mState = ComDrugMain.eState.onClose;

	// Token: 0x04004B5C RID: 19292
	private bool mIsMarkd;

	// Token: 0x02000EBC RID: 3772
	private enum eState
	{
		// Token: 0x04004B5E RID: 19294
		onOpen,
		// Token: 0x04004B5F RID: 19295
		onClose
	}
}
