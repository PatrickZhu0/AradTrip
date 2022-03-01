using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001B2C RID: 6956
	internal class FashionEquipFrame : ClientFrame
	{
		// Token: 0x0601115A RID: 69978 RVA: 0x004E5D3B File Offset: 0x004E413B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionEquipFrame";
		}

		// Token: 0x0601115B RID: 69979 RVA: 0x004E5D44 File Offset: 0x004E4144
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as FashionEquipFrameData);
			if (null != this.comDataBinder)
			{
				this.comDataBinder.SetSuit(this.data.eFashionType, this.data.Occu, this.data.SuitID);
			}
			base._AddButton("OK", delegate
			{
				if (!this.mMask)
				{
					this.frameMgr.CloseFrame<FashionEquipFrame>(this, false);
				}
			});
			base._AddButton("BtnEquipAll", delegate
			{
				this._EquipAllFashions();
				this.frameMgr.CloseFrame<FashionEquipFrame>(this, false);
			});
		}

		// Token: 0x0601115C RID: 69980 RVA: 0x004E5DCD File Offset: 0x004E41CD
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0601115D RID: 69981 RVA: 0x004E5DD0 File Offset: 0x004E41D0
		private void _EquipAllFashions()
		{
			int num = 0;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Fashion);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(item.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.Occu == this.data.Occu / 10)
						{
							if (tableItem.SuitID == this.data.SuitID)
							{
								if (tableItem.Type == (int)this.data.eFashionType)
								{
									int num2 = 1 << item.SubType;
									if ((num & num2) != num2)
									{
										num |= num2;
										DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400B00D RID: 45069
		[UIControl("", typeof(ComFashionEquipDataBinder), 0)]
		private ComFashionEquipDataBinder comDataBinder;

		// Token: 0x0400B00E RID: 45070
		private FashionEquipFrameData data;

		// Token: 0x0400B00F RID: 45071
		private bool mMask;
	}
}
