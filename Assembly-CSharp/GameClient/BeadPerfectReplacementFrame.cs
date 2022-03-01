using System;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001AC6 RID: 6854
	public class BeadPerfectReplacementFrame : ClientFrame
	{
		// Token: 0x06010D49 RID: 68937 RVA: 0x004CC741 File Offset: 0x004CAB41
		protected sealed override void _bindExUI()
		{
			this.mBeadPerfectReplacementView = this.mBind.GetCom<BeadPerfectReplacementView>("BeadPerfectReplacementView");
		}

		// Token: 0x06010D4A RID: 68938 RVA: 0x004CC759 File Offset: 0x004CAB59
		protected sealed override void _unbindExUI()
		{
			this.mBeadPerfectReplacementView = null;
		}

		// Token: 0x06010D4B RID: 68939 RVA: 0x004CC762 File Offset: 0x004CAB62
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/BeadPerfectReplacementFrame/BeadPerfectReplacementFrame";
		}

		// Token: 0x06010D4C RID: 68940 RVA: 0x004CC76C File Offset: 0x004CAB6C
		protected sealed override void _OnOpenFrame()
		{
			this.mModelData = (this.userData as BeadPerfectReplacementModel);
			if (this.mModelData != null)
			{
				this.mBeadPerfectReplacementView.InitView(this.mModelData, new BeadPerfectReplacementView.OnMountedItemSelect(this._OnMountedItemSelect), new BeadPerfectReplacementView.OnUnMountedItemSelect(this._OnUnMountedItemSelect), new BeadPerfectReplacementView.OnOkButtonClick(this._OnSendSceneReplacePreciousBeadReq), new UnityAction(this.OnCloseClick));
			}
		}

		// Token: 0x06010D4D RID: 68941 RVA: 0x004CC7D6 File Offset: 0x004CABD6
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mModelData = null;
			this.mBeadItemModel = null;
			this.mBeadItemData = null;
		}

		// Token: 0x06010D4E RID: 68942 RVA: 0x004CC7F4 File Offset: 0x004CABF4
		private void _OnMountedItemSelect(BeadItemModel model)
		{
			this.mBeadItemModel = model;
			ItemSimpleData mSimpleData = this._GetExpandItemData(model.beadItemData);
			if (this.mBeadPerfectReplacementView != null)
			{
				this.mBeadPerfectReplacementView.UpdateExpendGoldInfo(mSimpleData);
				this.mBeadPerfectReplacementView.RefreshBeadItemList();
			}
		}

		// Token: 0x06010D4F RID: 68943 RVA: 0x004CC83D File Offset: 0x004CAC3D
		private void _OnUnMountedItemSelect(ItemData data)
		{
			this.mBeadItemData = data;
		}

		// Token: 0x06010D50 RID: 68944 RVA: 0x004CC848 File Offset: 0x004CAC48
		private ItemSimpleData _GetExpandItemData(ItemData mBeadItemData)
		{
			ItemSimpleData result = null;
			if (mBeadItemData != null)
			{
				BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(mBeadItemData.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ReplacejewelsTable beadReplaceJewelsTableData = DataManager<BeadCardManager>.GetInstance().GetBeadReplaceJewelsTableData(tableItem.Color, tableItem.Level, tableItem.BeadType);
					if (beadReplaceJewelsTableData != null)
					{
						result = new ItemSimpleData(beadReplaceJewelsTableData.CostItem, beadReplaceJewelsTableData.CostNum);
					}
				}
			}
			return result;
		}

		// Token: 0x06010D51 RID: 68945 RVA: 0x004CC8B4 File Offset: 0x004CACB4
		private void _OnSendSceneReplacePreciousBeadReq()
		{
			if (this.mBeadItemModel == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("NoSelectInalyBeadDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mBeadItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("NoSelectedReplaceBeadDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			ItemSimpleData itemSimpleData = this._GetExpandItemData(this.mBeadItemData);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemSimpleData.ItemID, true);
			int count = itemSimpleData.Count;
			if (ownedItemCount < count)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("equip_upgrade_nomoney_notice"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			this.SendSceneReplacePreciousBeadReq();
		}

		// Token: 0x06010D52 RID: 68946 RVA: 0x004CC940 File Offset: 0x004CAD40
		private void SendSceneReplacePreciousBeadReq()
		{
			AdjustResultFrame.AdjustResultFrameData adjustResultFrameData = new AdjustResultFrame.AdjustResultFrameData();
			AdjustResultFrame.AdjustResultFrameData adjustResultFrameData2 = adjustResultFrameData;
			adjustResultFrameData2.callback = (UnityAction)Delegate.Combine(adjustResultFrameData2.callback, new UnityAction(delegate()
			{
				DataManager<BeadCardManager>.GetInstance().OnSendSceneReplacePreciousBeadReq((byte)this.mBeadItemModel.eqPrecHoleIndex, this.mBeadItemModel.equipItemData.GUID, this.mBeadItemData.GUID);
			}));
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mBeadItemModel.beadItemData.TableID);
			string text = string.Empty;
			string text2 = string.Empty;
			if (this.mBeadItemData.BeadAdditiveAttributeBuffID > 0)
			{
				text = string.Format("[<color=#809CB3FF>附加属性:</color>{0}]", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.mBeadItemData.BeadAdditiveAttributeBuffID));
			}
			if (this.mBeadItemModel.buffID > 0)
			{
				text2 = string.Format("[<color=#809CB3FF>附加属性:</color>{0}]", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.mBeadItemModel.buffID));
			}
			adjustResultFrameData.desc = string.Format("使用[{0}]{1}的[{2}]\n置换\n[{3}]{4}的[{5}]\n被置换的宝珠将退回背包，确定要置换？", new object[]
			{
				DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mBeadItemData.TableID, false),
				text,
				this.mBeadItemData.GetColorName(string.Empty, false),
				DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(this.mBeadItemModel.beadItemData.TableID, false),
				text2,
				commonItemTableDataByID.GetColorName(string.Empty, false)
			});
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjustResultFrame>(FrameLayer.Middle, adjustResultFrameData, string.Empty);
		}

		// Token: 0x06010D53 RID: 68947 RVA: 0x004CCA88 File Offset: 0x004CAE88
		private void OnCloseClick()
		{
			this.frameMgr.CloseFrame<BeadPerfectReplacementFrame>(this, false);
		}

		// Token: 0x0400ACA2 RID: 44194
		private BeadPerfectReplacementModel mModelData;

		// Token: 0x0400ACA3 RID: 44195
		private BeadItemModel mBeadItemModel;

		// Token: 0x0400ACA4 RID: 44196
		private ItemData mBeadItemData;

		// Token: 0x0400ACA5 RID: 44197
		private BeadPerfectReplacementView mBeadPerfectReplacementView;
	}
}
