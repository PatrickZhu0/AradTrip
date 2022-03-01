using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B1 RID: 5041
	public class SignFrame : ClientFrame
	{
		// Token: 0x0600C3AC RID: 50092 RVA: 0x002EE08B File Offset: 0x002EC48B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/SignFrame";
		}

		// Token: 0x0600C3AD RID: 50093 RVA: 0x002EE094 File Offset: 0x002EC494
		protected override void _OnOpenFrame()
		{
			this.monthlySignInItemData = null;
			if (this.userData != null && this.userData is ActivityDataManager.MonthlySignInItemData)
			{
				this.monthlySignInItemData = (ActivityDataManager.MonthlySignInItemData)this.userData;
			}
			this.CalcSignInCountInfo();
			this.m_iOnceCost = this._GetSignOnceCost();
			ActivityDataManager.MonthlySignInCountInfo monthlySignInCountInfo = DataManager<ActivityDataManager>.GetInstance().GetMonthlySignInCountInfo();
			if (monthlySignInCountInfo != null)
			{
				this.count0.text = TR.Value("count_info", (int)(monthlySignInCountInfo.noFree + monthlySignInCountInfo.free));
				this.count1.text = TR.Value("count_info", monthlySignInCountInfo.free);
				this.count2.text = TR.Value("count_info", monthlySignInCountInfo.activite);
			}
			this.m_kOnce = Utility.FindComponent<Text>(this.frame, "OnceHint/Text", true);
			int num = (this.m_iRpFree <= 0) ? this.m_iOnceCost : 0;
			this.m_kOnce.text = string.Format(TR.Value("sign_once_cost"), num);
			this.m_kAll = Utility.FindComponent<Text>(this.frame, "AllHint/Text", true);
			int num2 = (this.m_iSIRp - this.m_iRpFree) * this.m_iOnceCost;
			num2 = Mathf.Max(0, num2);
			this.m_kAll.text = string.Format(TR.Value("sign_once_cost"), num2);
			this.m_kGrayOnce = Utility.FindComponent<UIGray>(this.frame, "BtnOnce", true);
			this.m_kGrayAll = Utility.FindComponent<UIGray>(this.frame, "BtnAll", true);
			this.m_kBtnOnce = Utility.FindComponent<Button>(this.frame, "BtnOnce", true);
			this.m_kBtnAll = Utility.FindComponent<Button>(this.frame, "BtnAll", true);
			int num3 = this._GetSignMoneyID();
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num3, true);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num3, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.moneyIcon, tableItem.Icon, true);
			}
			this.m_kGrayOnce.enabled = (num > ownedItemCount);
			this.m_kBtnOnce.enabled = !this.m_kGrayOnce.enabled;
			this.m_kOnce.color = ((!this.m_kBtnOnce.enabled) ? Color.red : Color.green);
			this.m_kGrayAll.enabled = (num2 > ownedItemCount);
			this.m_kBtnAll.enabled = !this.m_kGrayAll.enabled;
			this.m_kAll.color = ((!this.m_kBtnAll.enabled) ? Color.red : Color.green);
			if (this.monthlySignInItemData != null && this.Item0 != null && this.monthlySignInItemData.awardItemData != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.monthlySignInItemData.awardItemData.ID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = this.monthlySignInItemData.awardItemData.Num;
					this.Item0.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
			}
		}

		// Token: 0x0600C3AE RID: 50094 RVA: 0x002EE3E9 File Offset: 0x002EC7E9
		protected override void _bindExUI()
		{
			this.Item0 = this.mBind.GetCom<ComItem>("Item0");
		}

		// Token: 0x0600C3AF RID: 50095 RVA: 0x002EE401 File Offset: 0x002EC801
		protected override void _unbindExUI()
		{
			this.Item0 = null;
		}

		// Token: 0x0600C3B0 RID: 50096 RVA: 0x002EE40C File Offset: 0x002EC80C
		private void CalcSignInCountInfo()
		{
			ActivityDataManager.MonthlySignInCountInfo monthlySignInCountInfo = DataManager<ActivityDataManager>.GetInstance().GetMonthlySignInCountInfo();
			if (monthlySignInCountInfo != null)
			{
				this.m_iSIRp = (int)(monthlySignInCountInfo.noFree + monthlySignInCountInfo.free + monthlySignInCountInfo.activite);
				this.m_iRpFree = (int)(monthlySignInCountInfo.free + monthlySignInCountInfo.activite);
				if (this.m_iRpFree < 0)
				{
					this.m_iRpFree = 0;
				}
			}
		}

		// Token: 0x0600C3B1 RID: 50097 RVA: 0x002EE46C File Offset: 0x002EC86C
		private int _GetSignMoneyID()
		{
			int result = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(242, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Value;
			}
			return result;
		}

		// Token: 0x0600C3B2 RID: 50098 RVA: 0x002EE4B0 File Offset: 0x002EC8B0
		private int _GetSignOnceCost()
		{
			int result = this.m_iCostDefault;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(243, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Value;
			}
			return result;
		}

		// Token: 0x0600C3B3 RID: 50099 RVA: 0x002EE4EC File Offset: 0x002EC8EC
		protected override void _OnCloseFrame()
		{
			this.monthlySignInItemData = null;
		}

		// Token: 0x0600C3B4 RID: 50100 RVA: 0x002EE4F8 File Offset: 0x002EC8F8
		[UIEventHandle("BtnOnce")]
		private void OnSignOnce()
		{
			if (DataManager<ActivityDataManager>.GetInstance().GetFillCheckCount() == 0)
			{
				SystemNotifyManager.SystemNotify(10044, string.Empty);
				return;
			}
			this.CalcSignInCountInfo();
			this.m_iOnceCost = this._GetSignOnceCost();
			int num = (this.m_iRpFree <= 0) ? this.m_iOnceCost : 0;
			int nMoneyID = this._GetSignMoneyID();
			if (num <= 0)
			{
				if (this.monthlySignInItemData != null)
				{
					DataManager<ActivityDataManager>.GetInstance().SendMonthlySignIn(this.monthlySignInItemData.day, false);
				}
				this.frameMgr.CloseFrame<SignFrame>(this, false);
			}
			else
			{
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = nMoneyID,
					nCount = num
				}, delegate
				{
					if (this.monthlySignInItemData != null)
					{
						DataManager<ActivityDataManager>.GetInstance().SendMonthlySignIn(this.monthlySignInItemData.day, false);
					}
					this.frameMgr.CloseFrame<SignFrame>(this, false);
				}, "common_money_cost", null);
			}
		}

		// Token: 0x04006F2B RID: 28459
		private string[] hints = new string[]
		{
			"还可以补签: <color=#00fe0cff>{0}</color>次",
			"还可以补签: <color=#FF0000FF>{0}</color>次",
			"还可以补签: <color=#00ff00FF>{0}</color>次",
			"还可以补签: <color=#00ff00FF>{0}</color>次",
			"免费补签: <color=#00fe0cff>{0}</color>次",
			"免费补签: <color=#00ff00FF>{0}</color>次",
			"免费补签: <color=#FF0000FF>{0}</color>次",
			"免费补签: <color=#00ff00FF>{0}</color>次"
		};

		// Token: 0x04006F2C RID: 28460
		[UIControl("count0", typeof(Text), 0)]
		private Text count0;

		// Token: 0x04006F2D RID: 28461
		[UIControl("count1", typeof(Text), 0)]
		private Text count1;

		// Token: 0x04006F2E RID: 28462
		[UIControl("count2", typeof(Text), 0)]
		private Text count2;

		// Token: 0x04006F2F RID: 28463
		private int m_iSIRp;

		// Token: 0x04006F30 RID: 28464
		private int m_iRpFree;

		// Token: 0x04006F31 RID: 28465
		private int m_iOnceCost;

		// Token: 0x04006F32 RID: 28466
		private Text m_kOnce;

		// Token: 0x04006F33 RID: 28467
		private Text m_kAll;

		// Token: 0x04006F34 RID: 28468
		private UIGray m_kGrayOnce;

		// Token: 0x04006F35 RID: 28469
		private UIGray m_kGrayAll;

		// Token: 0x04006F36 RID: 28470
		private Button m_kBtnOnce;

		// Token: 0x04006F37 RID: 28471
		private Button m_kBtnAll;

		// Token: 0x04006F38 RID: 28472
		[UIControl("MoneyIcon", typeof(Image), 0)]
		private Image moneyIcon;

		// Token: 0x04006F39 RID: 28473
		[UIControl("MoneyIcon1", typeof(Image), 0)]
		private Image moneyIcon1;

		// Token: 0x04006F3A RID: 28474
		private int m_iCostDefault = 20;

		// Token: 0x04006F3B RID: 28475
		private ComItem Item0;

		// Token: 0x04006F3C RID: 28476
		private ActivityDataManager.MonthlySignInItemData monthlySignInItemData;
	}
}
