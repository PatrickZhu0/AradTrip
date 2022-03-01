using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015D0 RID: 5584
	internal class EquipSubmitResultFrame : ClientFrame
	{
		// Token: 0x0600DACA RID: 56010 RVA: 0x00370CCC File Offset: 0x0036F0CC
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipRecovery/EquipSubmitResultFrame";
		}

		// Token: 0x0600DACB RID: 56011 RVA: 0x00370CD3 File Offset: 0x0036F0D3
		protected sealed override void _OnOpenFrame()
		{
			this._InitUI();
		}

		// Token: 0x0600DACC RID: 56012 RVA: 0x00370CDB File Offset: 0x0036F0DB
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0600DACD RID: 56013 RVA: 0x00370CDD File Offset: 0x0036F0DD
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DACE RID: 56014 RVA: 0x00370CDF File Offset: 0x0036F0DF
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DACF RID: 56015 RVA: 0x00370CE1 File Offset: 0x0036F0E1
		private void _InitUI()
		{
			this._InitRecord();
		}

		// Token: 0x0600DAD0 RID: 56016 RVA: 0x00370CEC File Offset: 0x0036F0EC
		private void _InitRecord()
		{
			List<EqRecScoreItem> submitResult = DataManager<EquipRecoveryDataManager>.GetInstance().submitResult;
			for (int i = 0; i < submitResult.Count; i++)
			{
				this._CreateSubmitItem(submitResult[i]);
			}
		}

		// Token: 0x0600DAD1 RID: 56017 RVA: 0x00370D28 File Offset: 0x0036F128
		private void _CreateSubmitItem(EqRecScoreItem scoreItem)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(scoreItem.uid);
			if (item == null)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/EquipRecovery/ResultItem", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(item.TableID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			GameObject gameObject2 = component.GetGameObject("itemRoot");
			Text com = component.GetCom<Text>("itemScore");
			ComItem comItem = gameObject2.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(gameObject2);
			}
			int result = item.TableID;
			comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(result);
			});
			this.scoreSum += (int)scoreItem.score;
			com.text = scoreItem.score.ToString();
			Utility.AttachTo(gameObject, this.mContentRoot, false);
		}

		// Token: 0x0600DAD2 RID: 56018 RVA: 0x00370E3C File Offset: 0x0036F23C
		private void _OnShowTips(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600DAD3 RID: 56019 RVA: 0x00370E64 File Offset: 0x0036F264
		protected override void _bindExUI()
		{
			this.mContentRoot = this.mBind.GetGameObject("ContentRoot");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600DAD4 RID: 56020 RVA: 0x00370EB9 File Offset: 0x0036F2B9
		protected override void _unbindExUI()
		{
			this.mContentRoot = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600DAD5 RID: 56021 RVA: 0x00370EE5 File Offset: 0x0036F2E5
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EquipSubmitResultFrame>(this, false);
		}

		// Token: 0x040080B4 RID: 32948
		private const string submitItemPath = "UIFlatten/Prefabs/EquipRecovery/ResultItem";

		// Token: 0x040080B5 RID: 32949
		private int scoreSum;

		// Token: 0x040080B6 RID: 32950
		private GameObject mContentRoot;

		// Token: 0x040080B7 RID: 32951
		private Button mClose;
	}
}
