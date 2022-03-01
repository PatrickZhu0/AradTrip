using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001A80 RID: 6784
	public class ShopNewFrame : ClientFrame
	{
		// Token: 0x06010A6A RID: 68202 RVA: 0x004B6FE8 File Offset: 0x004B53E8
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length != 3)
				{
					Logger.LogErrorFormat("ShopNewFrame.OpenLinkFrame paramArrayLength is not Right", new object[0]);
				}
				else
				{
					int num = int.Parse(array[0]);
					int shopChildrenId = int.Parse(array[1]);
					int shopItemType = int.Parse(array[2]);
					ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(num, string.Empty, string.Empty);
					if (tableItem == null)
					{
						Logger.LogErrorFormat("ShopNewFrame OpenLinkFrame The shopTable is null and shop id is {0}", new object[]
						{
							num
						});
					}
					else if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.OpenLevel)
					{
						string msgContent = string.Format(TR.Value("exchange_mall_not_open"), tableItem.OpenLevel, tableItem.ShopName);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else if (tableItem.BindType == ShopTable.eBindType.ACCOUNT_BIND)
					{
						if (DataManager<AccountShopDataManager>.GetInstance().CheckHasChildShop(num))
						{
							DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(num, shopChildrenId, 0, -1);
						}
						else
						{
							DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(num, 0, shopItemType, -1);
						}
					}
					else
					{
						DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(num, shopChildrenId, shopItemType, -1);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("ShopNewFrame.OpenLinkFrame:=>{0}" + ex.ToString(), new object[0]);
			}
		}

		// Token: 0x06010A6B RID: 68203 RVA: 0x004B715C File Offset: 0x004B555C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ShopNew/ShopNewFrame";
		}

		// Token: 0x06010A6C RID: 68204 RVA: 0x004B7164 File Offset: 0x004B5564
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			ShopNewParamData shopNewParamData = this.userData as ShopNewParamData;
			if (this.mShopNewView != null)
			{
				this.mShopNewView.InitShop(shopNewParamData);
			}
		}

		// Token: 0x06010A6D RID: 68205 RVA: 0x004B71A0 File Offset: 0x004B55A0
		protected override void _bindExUI()
		{
			this.mShopNewView = this.mBind.GetCom<ShopNewView>("ShopNewView");
		}

		// Token: 0x06010A6E RID: 68206 RVA: 0x004B71B8 File Offset: 0x004B55B8
		protected override void _unbindExUI()
		{
			this.mShopNewView = null;
		}

		// Token: 0x06010A6F RID: 68207 RVA: 0x004B71C1 File Offset: 0x004B55C1
		protected override void _OnCloseFrame()
		{
			DataManager<ShopNewDataManager>.GetInstance().ClearData();
		}

		// Token: 0x0400AA1C RID: 43548
		private ShopNewView mShopNewView;
	}
}
