using System;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001CC0 RID: 7360
	public class TreasureChooseFrame : ClientFrame
	{
		// Token: 0x060120E5 RID: 73957 RVA: 0x0054832E File Offset: 0x0054672E
		protected sealed override void _bindExUI()
		{
			this.mScrollView = this.mBind.GetCom<ComUIListScript>("ScrollView");
		}

		// Token: 0x060120E6 RID: 73958 RVA: 0x00548346 File Offset: 0x00546746
		protected sealed override void _unbindExUI()
		{
			this.mScrollView = null;
		}

		// Token: 0x060120E7 RID: 73959 RVA: 0x0054834F File Offset: 0x0054674F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TreasureConversionFrame/TreasureChooseFrame";
		}

		// Token: 0x060120E8 RID: 73960 RVA: 0x00548358 File Offset: 0x00546758
		protected sealed override void _OnOpenFrame()
		{
			this.param = (this.userData as TreasureChooseParam);
			if (this.param == null)
			{
				return;
			}
			this.InitComUIListScription();
			if (this.param.treasureChooseList != null)
			{
				this.mScrollView.SetElementAmount(this.param.treasureChooseList.Count);
			}
		}

		// Token: 0x060120E9 RID: 73961 RVA: 0x005483B3 File Offset: 0x005467B3
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitComUIListScription();
			this.param = null;
		}

		// Token: 0x060120EA RID: 73962 RVA: 0x005483C4 File Offset: 0x005467C4
		private void InitComUIListScription()
		{
			if (this.mScrollView != null)
			{
				this.mScrollView.Initialize();
				ComUIListScript comUIListScript = this.mScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mScrollView;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
			}
		}

		// Token: 0x060120EB RID: 73963 RVA: 0x00548464 File Offset: 0x00546864
		private void UnInitComUIListScription()
		{
			if (this.mScrollView != null)
			{
				ComUIListScript comUIListScript = this.mScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mScrollView;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
			}
		}

		// Token: 0x060120EC RID: 73964 RVA: 0x005484F7 File Offset: 0x005468F7
		private TreasureConversionItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<TreasureConversionItem>();
		}

		// Token: 0x060120ED RID: 73965 RVA: 0x00548500 File Offset: 0x00546900
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			TreasureConversionItem treasureConversionItem = item.gameObjectBindScript as TreasureConversionItem;
			if (treasureConversionItem != null && item.m_index >= 0 && item.m_index < this.param.treasureChooseList.Count)
			{
				treasureConversionItem.OnItemVisiable(this.param.treasureChooseList[item.m_index]);
			}
		}

		// Token: 0x060120EE RID: 73966 RVA: 0x00548568 File Offset: 0x00546968
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			TreasureConversionItem treasureConversionItem = item.gameObjectBindScript as TreasureConversionItem;
			if (treasureConversionItem != null)
			{
				if (this.param.treasureChooseCallback != null)
				{
					this.param.treasureChooseCallback(treasureConversionItem.TreasureItemData);
				}
				base.Close(false);
			}
		}

		// Token: 0x0400BC37 RID: 48183
		private ComUIListScript mScrollView;

		// Token: 0x0400BC38 RID: 48184
		private TreasureChooseParam param;
	}
}
