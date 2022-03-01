using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001510 RID: 5392
	public class ChampionshipSeaReliveView : MonoBehaviour
	{
		// Token: 0x0600D16C RID: 53612 RVA: 0x0033AAD3 File Offset: 0x00338ED3
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D16D RID: 53613 RVA: 0x0033AADB File Offset: 0x00338EDB
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D16E RID: 53614 RVA: 0x0033AAEC File Offset: 0x00338EEC
		private void BindUiEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
				this.okButton.onClick.AddListener(new UnityAction(this.OnOkButtonClick));
			}
			if (this.noButton != null)
			{
				this.noButton.onClick.RemoveAllListeners();
				this.noButton.onClick.AddListener(new UnityAction(this.OnNoButtonClick));
			}
		}

		// Token: 0x0600D16F RID: 53615 RVA: 0x0033AB74 File Offset: 0x00338F74
		private void UnBindUiEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
			}
			if (this.noButton != null)
			{
				this.noButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D170 RID: 53616 RVA: 0x0033ABC3 File Offset: 0x00338FC3
		private void ClearData()
		{
			this._isReliveTicketEnough = true;
		}

		// Token: 0x0600D171 RID: 53617 RVA: 0x0033ABCC File Offset: 0x00338FCC
		public void InitView()
		{
			this.InitReliveContent();
		}

		// Token: 0x0600D172 RID: 53618 RVA: 0x0033ABD4 File Offset: 0x00338FD4
		private void InitReliveContent()
		{
			if (this.reliveContentLabel != null)
			{
				string championshipReliveContentStr = this.GetChampionshipReliveContentStr();
				string finalStringByUpdateChangeLineFlag = CommonUtility.GetFinalStringByUpdateChangeLineFlag(championshipReliveContentStr);
				this.reliveContentLabel.text = finalStringByUpdateChangeLineFlag;
			}
		}

		// Token: 0x0600D173 RID: 53619 RVA: 0x0033AC0C File Offset: 0x0033900C
		private void OnOkButtonClick()
		{
			if (this._isReliveTicketEnough)
			{
				this.OnSendChampionReliveReq();
			}
			else
			{
				int championshipReliveCostPointTicketNumber = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipReliveCostPointTicketNumber();
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = 600000002;
				costInfo.nCount = championshipReliveCostPointTicketNumber;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, new Action(this.OnSendChampionReliveReq), "common_money_cost", null);
			}
		}

		// Token: 0x0600D174 RID: 53620 RVA: 0x0033AC6F File Offset: 0x0033906F
		private void OnSendChampionReliveReq()
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionReliveReq();
			ChampionshipUtility.OnCloseChampionshipSeaReliveFrame();
		}

		// Token: 0x0600D175 RID: 53621 RVA: 0x0033AC80 File Offset: 0x00339080
		private void OnNoButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipSeaReliveFrame();
		}

		// Token: 0x0600D176 RID: 53622 RVA: 0x0033AC88 File Offset: 0x00339088
		private string GetChampionshipReliveContentStr()
		{
			int championshipReliveItemId = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipReliveItemId();
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(championshipReliveItemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem.ID, true);
			if (ownedItemCount >= 1)
			{
				return TR.Value("Championship_Fight_Relive_Normal_Format", tableItem.Name);
			}
			this._isReliveTicketEnough = false;
			ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(600000002, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return string.Empty;
			}
			int championshipReliveCostPointTicketNumber = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipReliveCostPointTicketNumber();
			return TR.Value("Championship_Fight_Relive_Cost_Ticket_Format", championshipReliveCostPointTicketNumber, tableItem2.Name, tableItem.Name);
		}

		// Token: 0x04007A94 RID: 31380
		private bool _isReliveTicketEnough = true;

		// Token: 0x04007A95 RID: 31381
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Text reliveContentLabel;

		// Token: 0x04007A96 RID: 31382
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button okButton;

		// Token: 0x04007A97 RID: 31383
		[SerializeField]
		private Button noButton;
	}
}
