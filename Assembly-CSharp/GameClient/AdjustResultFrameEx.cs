using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AB7 RID: 6839
	internal class AdjustResultFrameEx : ClientFrame
	{
		// Token: 0x06010CCC RID: 68812 RVA: 0x004C9C55 File Offset: 0x004C8055
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/AdjustResultFrame";
		}

		// Token: 0x06010CCD RID: 68813 RVA: 0x004C9C5C File Offset: 0x004C805C
		protected sealed override void _OnOpenFrame()
		{
			CommonGetItemData commonGetItemData = this.userData as CommonGetItemData;
			if (commonGetItemData == null)
			{
				Logger.LogError("open CommonGetItemFrame, userdata is invalid");
				return;
			}
			this.mTitle.text = commonGetItemData.title;
			for (int i = 0; i < commonGetItemData.itemDatas.Count; i++)
			{
				ResultItemData resultItemData = commonGetItemData.itemDatas[i];
				GameObject gameObject = Object.Instantiate<GameObject>(this.mItem);
				if (gameObject != null)
				{
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.mItemParent, false);
					ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
					if (component != null)
					{
						GameObject gameObject2 = component.GetGameObject("itemParent");
						Text com = component.GetCom<Text>("itemname");
						base.CreateComItem(gameObject2).Setup(resultItemData.itemData, commonGetItemData.itemClickCallback);
						if (com != null)
						{
							com.text = resultItemData.desc;
						}
					}
				}
			}
			MonoSingleton<AudioManager>.instance.PlaySound(12);
		}

		// Token: 0x06010CCE RID: 68814 RVA: 0x004C9D5D File Offset: 0x004C815D
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06010CCF RID: 68815 RVA: 0x004C9D60 File Offset: 0x004C8160
		protected sealed override void _bindExUI()
		{
			this.mItemParent = this.mBind.GetGameObject("ItemParent");
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mItem = this.mBind.GetGameObject("item");
		}

		// Token: 0x06010CD0 RID: 68816 RVA: 0x004C9DAF File Offset: 0x004C81AF
		protected sealed override void _unbindExUI()
		{
			this.mItemParent = null;
			this.mTitle = null;
			this.mItem = null;
		}

		// Token: 0x06010CD1 RID: 68817 RVA: 0x004C9DC6 File Offset: 0x004C81C6
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<AdjustResultFrameEx>(this, false);
		}

		// Token: 0x0400AC35 RID: 44085
		private GameObject mItemParent;

		// Token: 0x0400AC36 RID: 44086
		private Text mTitle;

		// Token: 0x0400AC37 RID: 44087
		private GameObject mItem;
	}
}
