using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B2A RID: 6954
	internal class FashionAvatarSeleteFrame : ClientFrame
	{
		// Token: 0x06011149 RID: 69961 RVA: 0x004E590B File Offset: 0x004E3D0B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionAvatarSeleteFrame";
		}

		// Token: 0x0601114A RID: 69962 RVA: 0x004E5914 File Offset: 0x004E3D14
		private void _InitializeFashions()
		{
			if (null != this.comFashionListScript)
			{
				this.comFashionListScript.Initialize();
				this.comFashionListScript.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComGridItem>();
					}
					return null;
				};
				this.comFashionListScript.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (null != item && this.mDatas != null && item.m_index >= 0 && item.m_index < 80)
					{
						ComGridItem comGridItem = item.gameObjectBindScript as ComGridItem;
						if (null != comGridItem)
						{
							ItemData itemData = (item.m_index < this.mDatas.Count) ? this.mDatas[item.m_index] : null;
							comGridItem.OnItemVisible(itemData);
						}
					}
				};
				this.comFashionListScript.onItemSelected = delegate(ComUIListElementScript item)
				{
					if (null != item)
					{
						ComGridItem comGridItem = item.gameObjectBindScript as ComGridItem;
						if (null != comGridItem && null != this.comModelBinder)
						{
							this.mBindValue = comGridItem.Value;
							this.comModelBinder.SetFashion(comGridItem.Value);
						}
					}
				};
				this.comFashionListScript.onItemChageDisplay = delegate(ComUIListElementScript item, bool bSelect)
				{
					if (null != item)
					{
						ComGridItem comGridItem = item.gameObjectBindScript as ComGridItem;
						if (null != comGridItem)
						{
							comGridItem.OnItemChangeDisplay(bSelect);
						}
					}
				};
			}
		}

		// Token: 0x0601114B RID: 69963 RVA: 0x004E59BC File Offset: 0x004E3DBC
		private void _UnInitializeFashions()
		{
			if (null != this.comFashionListScript)
			{
				this.comFashionListScript.onBindItem = null;
				this.comFashionListScript.onItemVisiable = null;
				this.comFashionListScript.onItemSelected = null;
				this.comFashionListScript.onItemChageDisplay = null;
				this.comFashionListScript = null;
			}
		}

		// Token: 0x0601114C RID: 69964 RVA: 0x004E5A11 File Offset: 0x004E3E11
		private void _UpdateFashions()
		{
			if (null != this.comFashionListScript)
			{
				this.comFashionListScript.SetElementAmount(80);
			}
		}

		// Token: 0x0601114D RID: 69965 RVA: 0x004E5A34 File Offset: 0x004E3E34
		protected override void _OnOpenFrame()
		{
			this.mDatas = (this.userData as List<ItemData>);
			base._AddButton("middle/btOK", delegate
			{
				if (this.mBindValue != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNormalFashionSelected, this.mBindValue, null, null, null);
					this.mBindValue = null;
				}
				this.frameMgr.CloseFrame<FashionAvatarSeleteFrame>(this, false);
			});
			base._AddButton("middle/btRefresh", delegate
			{
				this._ResetFashions();
				if (null != this.comFashionListScript)
				{
					this.comFashionListScript.SelectElement(-1, true);
				}
				this.mBindValue = null;
			});
			base._AddButton("middle/btClose", delegate
			{
				this.frameMgr.CloseFrame<FashionAvatarSeleteFrame>(this, false);
			});
			this._InitializeFashions();
			this._UpdateFashions();
			this._InitAvatar();
			this._ResetFashions();
		}

		// Token: 0x0601114E RID: 69966 RVA: 0x004E5AAF File Offset: 0x004E3EAF
		private void _InitAvatar()
		{
			if (null != this.comModelBinder)
			{
				this.comModelBinder.LoadAvatar(DataManager<PlayerBaseData>.GetInstance().JobTableID);
				this.comModelBinder.LoadWeapon();
			}
		}

		// Token: 0x0601114F RID: 69967 RVA: 0x004E5AE4 File Offset: 0x004E3EE4
		private void _ResetFashions()
		{
			if (null != this.comModelBinder)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
				List<ItemData> list = new List<ItemData>();
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						list.Add(item);
					}
				}
				this.comModelBinder.SetFashions(list);
			}
		}

		// Token: 0x06011150 RID: 69968 RVA: 0x004E5B56 File Offset: 0x004E3F56
		protected override void _OnCloseFrame()
		{
			this.mDatas = null;
			this._UnInitializeFashions();
		}

		// Token: 0x0400B004 RID: 45060
		[UIControl("middle/ItemListView", typeof(ComUIListScript), 0)]
		private ComUIListScript comFashionListScript;

		// Token: 0x0400B005 RID: 45061
		[UIControl("middle/ActorShow", typeof(ComModelBinder), 0)]
		private ComModelBinder comModelBinder;

		// Token: 0x0400B006 RID: 45062
		private ItemData mBindValue;

		// Token: 0x0400B007 RID: 45063
		private List<ItemData> mDatas;
	}
}
