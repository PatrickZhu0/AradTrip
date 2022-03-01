using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001B45 RID: 6981
public class InscriptionExtractFrame : ClientFrame
{
	// Token: 0x06011213 RID: 70163 RVA: 0x004EA762 File Offset: 0x004E8B62
	public sealed override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionPickFrame";
	}

	// Token: 0x06011214 RID: 70164 RVA: 0x004EA769 File Offset: 0x004E8B69
	protected sealed override void _OnOpenFrame()
	{
		if (this.userData != null)
		{
			this.mInscriptionExtractItemDataList = (this.userData as List<InscriptionExtractItemData>);
		}
		this.InitInterface();
	}

	// Token: 0x06011215 RID: 70165 RVA: 0x004EA790 File Offset: 0x004E8B90
	protected sealed override void _OnCloseFrame()
	{
		if (this.mInscriptionExtractItemDataList != null)
		{
			this.mInscriptionExtractItemDataList.Clear();
		}
		if (this.mInscriptionConsumeList != null)
		{
			this.mInscriptionConsumeList.Clear();
		}
		if (this.mGoInscriptionConsumeList != null)
		{
			this.mGoInscriptionConsumeList.Clear();
		}
		this.iSuccessRate = 0;
		this.mCurrentData = null;
	}

	// Token: 0x06011216 RID: 70166 RVA: 0x004EA7F0 File Offset: 0x004E8BF0
	private void InitInterface()
	{
		if (this.mInscriptionExtractItemDataList.Count > 1)
		{
			this.mBothDesc.CustomActive(true);
		}
		else
		{
			this.mBothDesc.CustomActive(false);
		}
		if (this.mInscriptionExtractItemDataList.Count == 1)
		{
			this.mCurrentData = this.mInscriptionExtractItemDataList[0];
			GameObject gameObject = Object.Instantiate<GameObject>(this.mInscriptionItem);
			Utility.AttachTo(gameObject, this.mInscriptionRoot, false);
			gameObject.CustomActive(true);
			InscriptionExtractItem component = gameObject.GetComponent<InscriptionExtractItem>();
			if (component != null)
			{
				component.OnItemVisiable(this.mCurrentData, null, false, false);
			}
			this.UpdateInscriptionExtractConsum(this.mCurrentData.inscriptionItem.TableID);
			this.UpdateSuccessRateDesc(this.mCurrentData.inscriptionItem.TableID);
		}
		else
		{
			for (int i = 0; i < this.mInscriptionExtractItemDataList.Count; i++)
			{
				InscriptionExtractItemData inscriptionExtractData = this.mInscriptionExtractItemDataList[i];
				GameObject gameObject2 = Object.Instantiate<GameObject>(this.mInscriptionItem);
				Utility.AttachTo(gameObject2, this.mInscriptionRoot, false);
				gameObject2.CustomActive(true);
				InscriptionExtractItem component2 = gameObject2.GetComponent<InscriptionExtractItem>();
				if (component2 != null)
				{
					component2.OnItemVisiable(inscriptionExtractData, new UnityAction<InscriptionExtractItemData>(this.OnInscriptionItemClick), i == 0, true);
				}
			}
		}
	}

	// Token: 0x06011217 RID: 70167 RVA: 0x004EA93C File Offset: 0x004E8D3C
	private void UpdateInscriptionExtractConsum(int inscriptionId)
	{
		if (this.mGoInscriptionConsumeList != null && this.mGoInscriptionConsumeList.Count > 0)
		{
			for (int i = 0; i < this.mGoInscriptionConsumeList.Count; i++)
			{
				this.mGoInscriptionConsumeList[i].CustomActive(false);
			}
		}
		if (this.mInscriptionConsumeList != null)
		{
			this.mInscriptionConsumeList.Clear();
		}
		List<InscriptionConsume> inscriptionExtractConsume = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionExtractConsume(inscriptionId);
		this.mInscriptionConsumeList.AddRange(inscriptionExtractConsume);
		if (this.mInscriptionConsumeList != null)
		{
			for (int j = 0; j < this.mInscriptionConsumeList.Count; j++)
			{
				if (j < this.mGoInscriptionConsumeList.Count)
				{
					this.mGoInscriptionConsumeList[j].CustomActive(true);
					InscriptionExtractConsumeItem component = this.mGoInscriptionConsumeList[j].GetComponent<InscriptionExtractConsumeItem>();
					if (component != null)
					{
						component.OnItemVisiable(this.mInscriptionConsumeList[j]);
					}
				}
				else
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.mExpendItem);
					Utility.AttachTo(gameObject, this.mPickItemRoot, false);
					gameObject.CustomActive(true);
					InscriptionExtractConsumeItem component2 = gameObject.GetComponent<InscriptionExtractConsumeItem>();
					if (component2 != null)
					{
						component2.OnItemVisiable(this.mInscriptionConsumeList[j]);
					}
					this.mGoInscriptionConsumeList.Add(gameObject);
				}
			}
		}
	}

	// Token: 0x06011218 RID: 70168 RVA: 0x004EAA9C File Offset: 0x004E8E9C
	private void UpdateSuccessRateDesc(int inscriptionid)
	{
		this.iSuccessRate = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionExtractSuccessRate(inscriptionid);
		if (this.mSuccessRate != null)
		{
			this.mSuccessRate.text = string.Format("摘取成功率:{0}", DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionExtractSuccessRateDesc(this.iSuccessRate));
		}
	}

	// Token: 0x06011219 RID: 70169 RVA: 0x004EAAF0 File Offset: 0x004E8EF0
	private void OnInscriptionItemClick(InscriptionExtractItemData data)
	{
		this.mCurrentData = data;
		if (data == null)
		{
			return;
		}
		this.UpdateInscriptionExtractConsum(data.inscriptionItem.TableID);
		this.UpdateSuccessRateDesc(data.inscriptionItem.TableID);
	}

	// Token: 0x0601121A RID: 70170 RVA: 0x004EAB24 File Offset: 0x004E8F24
	protected sealed override void _bindExUI()
	{
		this.mBothDesc = this.mBind.GetGameObject("BothDesc");
		this.mInscriptionRoot = this.mBind.GetGameObject("InscriptionRoot");
		this.mPickItemRoot = this.mBind.GetGameObject("PickItemRoot");
		this.mSuccessRate = this.mBind.GetCom<Text>("successRate");
		this.mOk = this.mBind.GetCom<Button>("Ok");
		if (null != this.mOk)
		{
			this.mOk.onClick.AddListener(new UnityAction(this._onOkButtonClick));
		}
		this.mInscriptionItem = this.mBind.GetGameObject("InscriptionItem");
		this.mExpendItem = this.mBind.GetGameObject("ExpendItem");
		this.mClose = this.mBind.GetCom<Button>("Close");
		if (null != this.mClose)
		{
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}
	}

	// Token: 0x0601121B RID: 70171 RVA: 0x004EAC3C File Offset: 0x004E903C
	protected sealed override void _unbindExUI()
	{
		this.mBothDesc = null;
		this.mInscriptionRoot = null;
		this.mPickItemRoot = null;
		this.mSuccessRate = null;
		if (null != this.mOk)
		{
			this.mOk.onClick.RemoveListener(new UnityAction(this._onOkButtonClick));
		}
		this.mOk = null;
		this.mInscriptionItem = null;
		this.mExpendItem = null;
		if (null != this.mClose)
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
		}
		this.mClose = null;
	}

	// Token: 0x0601121C RID: 70172 RVA: 0x004EACDC File Offset: 0x004E90DC
	private void _onOkButtonClick()
	{
		if (this.mCurrentData == null)
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < this.mInscriptionConsumeList.Count; i++)
		{
			InscriptionConsume inscriptionConsume = this.mInscriptionConsumeList[i];
			int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(inscriptionConsume.itemId);
			int count = inscriptionConsume.count;
			if (itemCountInPackage < count)
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			SystemNotifyManager.SysNotifyTextAnimation("摘取失败,摘取材料不足", CommonTipsDesc.eShowMode.SI_UNIQUE);
			return;
		}
		if (this.iSuccessRate / 1000 >= 1)
		{
			string msgContent = "您确定要摘下该铭文吗?本次摘取必定成功。";
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<InscriptionMosaicDataManager>.GetInstance().OnSceneEquipInscriptionExtractReq(this.mCurrentData.equipmentItem.GUID, (uint)this.mCurrentData.inscriptionItem.TableID, (uint)this.mCurrentData.index);
			}, null, 0f, false);
			return;
		}
		string msgContent2 = string.Format("您确定要摘下该铭文吗?本次摘取成功率[{0}]，摘取失败铭文将消失。", DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionExtractSuccessRateDesc(this.iSuccessRate));
		SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent2, delegate()
		{
			DataManager<InscriptionMosaicDataManager>.GetInstance().OnSceneEquipInscriptionExtractReq(this.mCurrentData.equipmentItem.GUID, (uint)this.mCurrentData.inscriptionItem.TableID, (uint)this.mCurrentData.index);
		}, null, 0f, false);
	}

	// Token: 0x0601121D RID: 70173 RVA: 0x004EADC4 File Offset: 0x004E91C4
	private void _onCloseButtonClick()
	{
		this.frameMgr.CloseFrame<InscriptionExtractFrame>(this, false);
	}

	// Token: 0x0400B09E RID: 45214
	private List<InscriptionExtractItemData> mInscriptionExtractItemDataList = new List<InscriptionExtractItemData>();

	// Token: 0x0400B09F RID: 45215
	private List<InscriptionConsume> mInscriptionConsumeList = new List<InscriptionConsume>();

	// Token: 0x0400B0A0 RID: 45216
	private List<GameObject> mGoInscriptionConsumeList = new List<GameObject>();

	// Token: 0x0400B0A1 RID: 45217
	private int iSuccessRate;

	// Token: 0x0400B0A2 RID: 45218
	private InscriptionExtractItemData mCurrentData;

	// Token: 0x0400B0A3 RID: 45219
	private GameObject mBothDesc;

	// Token: 0x0400B0A4 RID: 45220
	private GameObject mInscriptionRoot;

	// Token: 0x0400B0A5 RID: 45221
	private GameObject mPickItemRoot;

	// Token: 0x0400B0A6 RID: 45222
	private Text mSuccessRate;

	// Token: 0x0400B0A7 RID: 45223
	private Button mOk;

	// Token: 0x0400B0A8 RID: 45224
	private GameObject mInscriptionItem;

	// Token: 0x0400B0A9 RID: 45225
	private GameObject mExpendItem;

	// Token: 0x0400B0AA RID: 45226
	private Button mClose;
}
