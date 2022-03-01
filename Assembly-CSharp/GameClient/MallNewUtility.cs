using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012AE RID: 4782
	public static class MallNewUtility
	{
		// Token: 0x0600B82F RID: 47151 RVA: 0x002A258D File Offset: 0x002A098D
		public static void OnCloseMallNewFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
			}
		}

		// Token: 0x0600B830 RID: 47152 RVA: 0x002A25AC File Offset: 0x002A09AC
		public static List<MallNewIntergralMallTabData> GetIntergralMallTabDataModelList()
		{
			List<MallNewIntergralMallTabData> list = new List<MallNewIntergralMallTabData>();
			MallNewIntergralMallTabData item = new MallNewIntergralMallTabData
			{
				index = 0,
				mallTypeTableId = 22
			};
			list.Add(item);
			return list;
		}

		// Token: 0x0600B831 RID: 47153 RVA: 0x002A25E0 File Offset: 0x002A09E0
		public static int GetIntergralMallTicketUpper()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(612, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.Value;
		}

		// Token: 0x0600B832 RID: 47154 RVA: 0x002A2618 File Offset: 0x002A0A18
		public static int GetMallTicketConvertIntergalRate()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(613, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.Value;
		}

		// Token: 0x0600B833 RID: 47155 RVA: 0x002A264D File Offset: 0x002A0A4D
		public static int GetTicketConvertIntergalNumnber(int ticket)
		{
			return ticket * MallNewUtility.GetMallTicketConvertIntergalRate();
		}

		// Token: 0x0600B834 RID: 47156 RVA: 0x002A2658 File Offset: 0x002A0A58
		public static void CommonIntergralMallPopupWindow(string content, OnCommonMsgBoxToggleClick onToggleClick, Action onRureClick)
		{
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = content,
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = onToggleClick,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onRureClick
			});
		}

		// Token: 0x0600B835 RID: 47157 RVA: 0x002A26AD File Offset: 0x002A0AAD
		public static void ItemMallIntergralMallScoreIsEqual(bool value)
		{
			DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual = value;
		}

		// Token: 0x0600B836 RID: 47158 RVA: 0x002A26BA File Offset: 0x002A0ABA
		public static void ItemMallIntergralMallScoreIsExceed(bool value)
		{
			DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed = value;
		}

		// Token: 0x0600B837 RID: 47159 RVA: 0x002A26C7 File Offset: 0x002A0AC7
		public static bool IsMallItemCanCreditPointDeduction(MallItemInfo mallItemInfo)
		{
			return mallItemInfo != null && mallItemInfo.creditPointDeduction == 1U;
		}
	}
}
