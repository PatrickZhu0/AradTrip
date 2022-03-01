using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001939 RID: 6457
	public class ZillionaireGameRuleFrame : ClientFrame
	{
		// Token: 0x0600FB0E RID: 64270 RVA: 0x0044C8AC File Offset: 0x0044ACAC
		protected override void _bindExUI()
		{
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
		}

		// Token: 0x0600FB0F RID: 64271 RVA: 0x0044C901 File Offset: 0x0044AD01
		protected override void _unbindExUI()
		{
			this.mUIList = null;
			this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mBtnClose = null;
		}

		// Token: 0x0600FB10 RID: 64272 RVA: 0x0044C92D File Offset: 0x0044AD2D
		private void _onBtnCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ZillionaireGameRuleFrame>(this, false);
		}

		// Token: 0x0600FB11 RID: 64273 RVA: 0x0044C93C File Offset: 0x0044AD3C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/ZillionaireGameRuleFrame";
		}

		// Token: 0x0600FB12 RID: 64274 RVA: 0x0044C943 File Offset: 0x0044AD43
		protected override void _OnOpenFrame()
		{
			this.InitUIList();
		}

		// Token: 0x0600FB13 RID: 64275 RVA: 0x0044C94C File Offset: 0x0044AD4C
		private void InitUIList()
		{
			if (this.mUIList != null)
			{
				this.mUIList.Initialize();
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				this.mUIList.SetElementAmount(DataManager<ZillionaireGameDataManager>.GetInstance().ruleDescList.Count);
			}
		}

		// Token: 0x0600FB14 RID: 64276 RVA: 0x0044C9DD File Offset: 0x0044ADDD
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600FB15 RID: 64277 RVA: 0x0044C9E8 File Offset: 0x0044ADE8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < DataManager<ZillionaireGameDataManager>.GetInstance().ruleDescList.Count)
			{
				MapGridItemData mapGridItemData = DataManager<ZillionaireGameDataManager>.GetInstance().ruleDescList[item.m_index];
				Text com = comCommonBind.GetCom<Text>("Name");
				Text com2 = comCommonBind.GetCom<Text>("Desc");
				Text com3 = comCommonBind.GetCom<Text>("itemCount");
				Image com4 = comCommonBind.GetCom<Image>("itemIcon");
				if (com4 != null)
				{
					ETCImageLoader.LoadSprite(ref com4, mapGridItemData.gridIconPath, true);
				}
				if (com3 != null)
				{
					com3.text = ((mapGridItemData.itemCount <= 0) ? string.Empty : string.Format("x{0}", mapGridItemData.itemCount));
				}
				if (com != null)
				{
					com.text = mapGridItemData.gridName;
				}
				if (com2 != null)
				{
					com2.text = mapGridItemData.gridDesc;
				}
			}
		}

		// Token: 0x0600FB16 RID: 64278 RVA: 0x0044CB06 File Offset: 0x0044AF06
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x04009CE2 RID: 40162
		private ComUIListScript mUIList;

		// Token: 0x04009CE3 RID: 40163
		private Button mBtnClose;
	}
}
