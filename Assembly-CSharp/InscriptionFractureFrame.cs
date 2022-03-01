using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001B47 RID: 6983
public class InscriptionFractureFrame : ClientFrame
{
	// Token: 0x06011227 RID: 70183 RVA: 0x004EAFF2 File Offset: 0x004E93F2
	public sealed override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionFractureFrame";
	}

	// Token: 0x06011228 RID: 70184 RVA: 0x004EAFF9 File Offset: 0x004E93F9
	protected sealed override void _OnOpenFrame()
	{
		if (this.userData != null)
		{
			this.mInscriptionExtractItemDataList = (this.userData as List<InscriptionExtractItemData>);
		}
		this.InitInterface();
	}

	// Token: 0x06011229 RID: 70185 RVA: 0x004EB020 File Offset: 0x004E9420
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

	// Token: 0x0601122A RID: 70186 RVA: 0x004EB080 File Offset: 0x004E9480
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

	// Token: 0x0601122B RID: 70187 RVA: 0x004EB1CC File Offset: 0x004E95CC
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
		List<InscriptionConsume> inscriptionFractureConsume = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionFractureConsume(inscriptionId);
		this.mInscriptionConsumeList.AddRange(inscriptionFractureConsume);
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

	// Token: 0x0601122C RID: 70188 RVA: 0x004EB32C File Offset: 0x004E972C
	private void UpdateSuccessRateDesc(int inscriptionid)
	{
		this.iSuccessRate = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionFractureSuccessRate(inscriptionid);
		if (this.mSuccessRate != null)
		{
			this.mSuccessRate.text = string.Format("碎裂成功率:{0}", DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionExtractSuccessRateDesc(this.iSuccessRate));
		}
	}

	// Token: 0x0601122D RID: 70189 RVA: 0x004EB380 File Offset: 0x004E9780
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

	// Token: 0x0601122E RID: 70190 RVA: 0x004EB3B4 File Offset: 0x004E97B4
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

	// Token: 0x0601122F RID: 70191 RVA: 0x004EB4CC File Offset: 0x004E98CC
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

	// Token: 0x06011230 RID: 70192 RVA: 0x004EB56C File Offset: 0x004E996C
	private void _onOkButtonClick()
	{
		if (this.mCurrentData == null)
		{
			Logger.LogErrorFormat("InscriptionFractureFrame [_onOkButtonClick] mCurrentData = null", new object[0]);
			return;
		}
		if (this.mCurrentData.inscriptionItem == null)
		{
			Logger.LogErrorFormat("InscriptionFractureFrame [_onOkButtonClick] mCurrentData.inscriptionItem = null", new object[0]);
			return;
		}
		if (this.mCurrentData.equipmentItem == null)
		{
			Logger.LogErrorFormat("InscriptionFractureFrame [_onOkButtonClick] mCurrentData.equipmentItem = null", new object[0]);
			return;
		}
		List<CostItemManager.CostInfo> list = new List<CostItemManager.CostInfo>();
		if (this.mInscriptionConsumeList != null)
		{
			for (int i = 0; i < this.mInscriptionConsumeList.Count; i++)
			{
				InscriptionConsume inscriptionConsume = this.mInscriptionConsumeList[i];
				if (inscriptionConsume != null)
				{
					list.Add(new CostItemManager.CostInfo
					{
						nMoneyID = inscriptionConsume.itemId,
						nCount = inscriptionConsume.count
					});
				}
			}
		}
		DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(list, delegate
		{
			string msgContent = string.Format("本次碎裂的铭文为[{0}],您确定要碎裂该铭文吗?", this.mCurrentData.inscriptionItem.GetColorName(string.Empty, false));
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<InscriptionMosaicDataManager>.GetInstance().OnSceneEquipInscriptionDestroyReq(this.mCurrentData.equipmentItem.GUID, (uint)this.mCurrentData.inscriptionItem.TableID, (uint)this.mCurrentData.index);
			}, null, 0f, false);
		}, null, "common_money_cost");
	}

	// Token: 0x06011231 RID: 70193 RVA: 0x004EB65E File Offset: 0x004E9A5E
	private void _onCloseButtonClick()
	{
		this.frameMgr.CloseFrame<InscriptionFractureFrame>(this, false);
	}

	// Token: 0x0400B0B1 RID: 45233
	private List<InscriptionExtractItemData> mInscriptionExtractItemDataList = new List<InscriptionExtractItemData>();

	// Token: 0x0400B0B2 RID: 45234
	private List<InscriptionConsume> mInscriptionConsumeList = new List<InscriptionConsume>();

	// Token: 0x0400B0B3 RID: 45235
	private List<GameObject> mGoInscriptionConsumeList = new List<GameObject>();

	// Token: 0x0400B0B4 RID: 45236
	private int iSuccessRate;

	// Token: 0x0400B0B5 RID: 45237
	private InscriptionExtractItemData mCurrentData;

	// Token: 0x0400B0B6 RID: 45238
	private GameObject mBothDesc;

	// Token: 0x0400B0B7 RID: 45239
	private GameObject mInscriptionRoot;

	// Token: 0x0400B0B8 RID: 45240
	private GameObject mPickItemRoot;

	// Token: 0x0400B0B9 RID: 45241
	private Text mSuccessRate;

	// Token: 0x0400B0BA RID: 45242
	private Button mOk;

	// Token: 0x0400B0BB RID: 45243
	private GameObject mInscriptionItem;

	// Token: 0x0400B0BC RID: 45244
	private GameObject mExpendItem;

	// Token: 0x0400B0BD RID: 45245
	private Button mClose;
}
