using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001963 RID: 6499
	public class VipZeroControl : MonoBehaviour
	{
		// Token: 0x0600FCB2 RID: 64690 RVA: 0x0045830D File Offset: 0x0045670D
		private void Awake()
		{
		}

		// Token: 0x0600FCB3 RID: 64691 RVA: 0x0045830F File Offset: 0x0045670F
		private void OnDestroy()
		{
		}

		// Token: 0x0600FCB4 RID: 64692 RVA: 0x00458314 File Offset: 0x00456714
		public void InitControl()
		{
			ExpTable expTableByMaxLevelInAccount = PlayerUtility.GetExpTableByMaxLevelInAccount();
			if (this.creditTicketItemInMonth != null)
			{
				VipPrivilegeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>(24, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string iconPath = tableItem.IconPath;
					int num = tableItem.VIP0;
					if (expTableByMaxLevelInAccount.CreditPointMonthGetNum >= num)
					{
						num = expTableByMaxLevelInAccount.CreditPointMonthGetNum;
					}
					string arg = string.Format(tableItem.Description, num);
					string itemContentStr = TR.Value("Coin_Deal_Vip_Privilege_Item_Content_Format", this._creditTicketItemInMonthIndex, arg);
					this.creditTicketItemInMonth.InitItem(iconPath, itemContentStr);
				}
			}
			if (this.creditTicketItemInSelf != null)
			{
				VipPrivilegeTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>(25, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					string iconPath2 = tableItem2.IconPath;
					int num2 = tableItem2.VIP0;
					if (expTableByMaxLevelInAccount.CreditPointOwnNum >= num2)
					{
						num2 = expTableByMaxLevelInAccount.CreditPointOwnNum;
					}
					string arg2 = string.Format(tableItem2.Description, num2);
					string itemContentStr2 = TR.Value("Coin_Deal_Vip_Privilege_Item_Content_Format", this._creditTicketItemInSelfIndex, arg2);
					this.creditTicketItemInSelf.InitItem(iconPath2, itemContentStr2);
				}
			}
			if (this.creditTicketItemTransferLimit != null)
			{
				VipPrivilegeTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>(26, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					string iconPath3 = tableItem3.IconPath;
					int num3 = tableItem3.VIP0;
					if (expTableByMaxLevelInAccount.CreditPointMonthConversionNum >= num3)
					{
						num3 = expTableByMaxLevelInAccount.CreditPointMonthConversionNum;
					}
					string arg3 = string.Format(tableItem3.Description, num3);
					string itemContentStr3 = TR.Value("Coin_Deal_Vip_Privilege_Item_Content_Format", this._creditTicketItemTransferLimitIndex, arg3);
					this.creditTicketItemTransferLimit.InitItem(iconPath3, itemContentStr3);
				}
			}
			this.ResetContentRectTransform();
		}

		// Token: 0x0600FCB5 RID: 64693 RVA: 0x004584DE File Offset: 0x004568DE
		public void OnEnableControl()
		{
			this.ResetContentRectTransform();
		}

		// Token: 0x0600FCB6 RID: 64694 RVA: 0x004584E8 File Offset: 0x004568E8
		private void ResetContentRectTransform()
		{
			if (this.contentRectTransform == null)
			{
				return;
			}
			Vector3 localPosition = this.contentRectTransform.localPosition;
			this.contentRectTransform.localPosition = new Vector3(0f, localPosition.y, localPosition.z);
		}

		// Token: 0x04009E80 RID: 40576
		private int _creditTicketItemInMonthIndex = 4;

		// Token: 0x04009E81 RID: 40577
		private int _creditTicketItemInSelfIndex = 5;

		// Token: 0x04009E82 RID: 40578
		private int _creditTicketItemTransferLimitIndex = 6;

		// Token: 0x04009E83 RID: 40579
		private const int CreditTicketItemInMonthId = 24;

		// Token: 0x04009E84 RID: 40580
		private const int CreditTicketItemInSelfId = 25;

		// Token: 0x04009E85 RID: 40581
		private const int CreditTicketItemTransferLimitId = 26;

		// Token: 0x04009E86 RID: 40582
		[Space(10f)]
		[Header("ComToggleItem")]
		[Space(5f)]
		[SerializeField]
		private VipPrivilegeItem creditTicketItemInMonth;

		// Token: 0x04009E87 RID: 40583
		[SerializeField]
		private VipPrivilegeItem creditTicketItemInSelf;

		// Token: 0x04009E88 RID: 40584
		[SerializeField]
		private VipPrivilegeItem creditTicketItemTransferLimit;

		// Token: 0x04009E89 RID: 40585
		[Space(10f)]
		[Header("ContentRtf")]
		[Space(5f)]
		[SerializeField]
		private RectTransform contentRectTransform;
	}
}
