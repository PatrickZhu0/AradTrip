using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200143C RID: 5180
	public class ArtifactJarRewardPreviewFrame : ClientFrame
	{
		// Token: 0x0600C90E RID: 51470 RVA: 0x0030E6A0 File Offset: 0x0030CAA0
		protected override void _bindExUI()
		{
			this.mItemComUIList = this.mBind.GetCom<ComUIListScript>("ItemComUIList");
			this.mItemRoot = this.mBind.GetGameObject("ItemRoot");
			this.mDes = this.mBind.GetCom<Text>("des");
		}

		// Token: 0x0600C90F RID: 51471 RVA: 0x0030E6EF File Offset: 0x0030CAEF
		protected override void _unbindExUI()
		{
			this.mItemComUIList = null;
			this.mItemRoot = null;
			this.mDes = null;
		}

		// Token: 0x0600C910 RID: 51472 RVA: 0x0030E706 File Offset: 0x0030CB06
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ArtifactJar/ArtifactJarRewardPreviewFrame";
		}

		// Token: 0x0600C911 RID: 51473 RVA: 0x0030E710 File Offset: 0x0030CB10
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.artifactJarRewardData = (ArtifactJarRewardData)this.userData;
				this._BindUIEvent();
				this._InitComUIList();
				if (this.artifactJarRewardData.itemList != null)
				{
					this.mItemComUIList.SetElementAmount(this.artifactJarRewardData.itemList.Count);
				}
				if (this.artifactJarRewardData.desc == null)
				{
					this.mDes.CustomActive(false);
				}
				else
				{
					this.mDes.CustomActive(true);
					this.mDes.text = this.artifactJarRewardData.desc;
				}
			}
		}

		// Token: 0x0600C912 RID: 51474 RVA: 0x0030E7B4 File Offset: 0x0030CBB4
		private void _InitComUIList()
		{
			this.mItemComUIList.Initialize();
			this.mItemComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (this.artifactJarRewardData != null && this.artifactJarRewardData.itemList != null && item.m_index >= 0 && item.m_index < this.artifactJarRewardData.itemList.Count)
				{
					ComItem comItem = item.gameObject.GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(item.gameObject);
					}
					ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)this.artifactJarRewardData.itemList[item.m_index].id, 100, 0);
					if (ItemDetailData == null)
					{
						return;
					}
					ItemDetailData.Count = (int)this.artifactJarRewardData.itemList[item.m_index].num;
					comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
					{
						this._OnShowTips(ItemDetailData);
					});
				}
			};
			this.mItemComUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
			};
		}

		// Token: 0x0600C913 RID: 51475 RVA: 0x0030E80B File Offset: 0x0030CC0B
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600C914 RID: 51476 RVA: 0x0030E824 File Offset: 0x0030CC24
		protected override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
		}

		// Token: 0x0600C915 RID: 51477 RVA: 0x0030E82C File Offset: 0x0030CC2C
		private void _BindUIEvent()
		{
		}

		// Token: 0x0600C916 RID: 51478 RVA: 0x0030E82E File Offset: 0x0030CC2E
		private void _UnBindUIEvent()
		{
		}

		// Token: 0x0400740B RID: 29707
		private ArtifactJarRewardData artifactJarRewardData = new ArtifactJarRewardData();

		// Token: 0x0400740C RID: 29708
		private ComUIListScript mItemComUIList;

		// Token: 0x0400740D RID: 29709
		private GameObject mItemRoot;

		// Token: 0x0400740E RID: 29710
		private Text mDes;
	}
}
