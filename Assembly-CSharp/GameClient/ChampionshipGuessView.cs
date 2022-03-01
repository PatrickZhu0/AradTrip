using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014FA RID: 5370
	public class ChampionshipGuessView : MonoBehaviour
	{
		// Token: 0x0600D069 RID: 53353 RVA: 0x00336F3C File Offset: 0x0033533C
		private void Awake()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.betRecordButton != null)
			{
				this.betRecordButton.onClick.RemoveAllListeners();
				this.betRecordButton.onClick.AddListener(new UnityAction(this.OnBetRecordButtonClick));
			}
		}

		// Token: 0x0600D06A RID: 53354 RVA: 0x00336FC4 File Offset: 0x003353C4
		private void OnDestroy()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.betRecordButton != null)
			{
				this.betRecordButton.onClick.RemoveAllListeners();
			}
			this.ClearData();
		}

		// Token: 0x0600D06B RID: 53355 RVA: 0x00337019 File Offset: 0x00335419
		private void ClearData()
		{
			this._selectTabId = 0;
			this._firstWinnerGuessView = null;
			this._singleWinnerGuessView = null;
			this._funnyGuessView = null;
		}

		// Token: 0x0600D06C RID: 53356 RVA: 0x00337038 File Offset: 0x00335438
		public void InitView()
		{
			if (ChampionshipUtility.IsChampionshipTopPlayerNotExist() || ChampionshipUtility.IsChampionshipFightRaceNotExist())
			{
				DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionshipFightRaceData();
			}
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionAllGuessProjectReq();
			DataManager<ChampionshipDataManager>.GetInstance().SetChampionshipRequestGuessProjectDataInterval();
			this.InitMoneyControl();
			this.InitGuessTabControl();
			this.UpdateGuessContent();
		}

		// Token: 0x0600D06D RID: 53357 RVA: 0x00337089 File Offset: 0x00335489
		private void InitMoneyControl()
		{
			if (this.comMoneyControl != null)
			{
				this.comMoneyControl.InitMoneyItem(330000271, true, CounterKeys.COUNTER_CHAMPIONSHIP_GUESS_ITEM);
			}
		}

		// Token: 0x0600D06E RID: 53358 RVA: 0x003370B4 File Offset: 0x003354B4
		private void InitGuessTabControl()
		{
			this._selectTabId = this.GetDefaultSelectGuessTabId();
			List<ComControlDataEx> comControlDataExInGuessType = ChampionshipUtility.GetComControlDataExInGuessType(this._selectTabId);
			if (this.tabControlEx != null)
			{
				this.tabControlEx.InitComToggleControlEx(comControlDataExInGuessType, new OnComToggleItemExClick(this.OnComToggleItemExClick), null);
			}
		}

		// Token: 0x0600D06F RID: 53359 RVA: 0x00337103 File Offset: 0x00335503
		private void OnComToggleItemExClick(ComControlDataEx comToggleDataEx)
		{
			if (comToggleDataEx == null)
			{
				return;
			}
			if (comToggleDataEx.Id == this._selectTabId)
			{
				return;
			}
			this._selectTabId = comToggleDataEx.Id;
			this.UpdateGuessContent();
		}

		// Token: 0x0600D070 RID: 53360 RVA: 0x00337130 File Offset: 0x00335530
		private void UpdateGuessContent()
		{
			ChampionshipGuessType selectTabId = (ChampionshipGuessType)this._selectTabId;
			CommonUtility.UpdateGameObjectVisible(this.firstWinnerGuessViewRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.singleWinnerGuessViewRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.funnyGuessViewRoot, false);
			if (selectTabId == ChampionshipGuessType.FirstWinner)
			{
				CommonUtility.UpdateGameObjectVisible(this.firstWinnerGuessViewRoot, true);
				if (this._firstWinnerGuessView == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.firstWinnerGuessViewRoot);
					if (gameObject != null)
					{
						this._firstWinnerGuessView = gameObject.GetComponent<ChampionshipFirstWinnerGuessView>();
						if (this._firstWinnerGuessView != null)
						{
							this._firstWinnerGuessView.InitView();
						}
					}
				}
				else
				{
					this._firstWinnerGuessView.OnEnableView();
				}
			}
			else if (selectTabId == ChampionshipGuessType.SingleWinner)
			{
				CommonUtility.UpdateGameObjectVisible(this.singleWinnerGuessViewRoot, true);
				if (this._singleWinnerGuessView == null)
				{
					GameObject gameObject2 = CommonUtility.LoadGameObject(this.singleWinnerGuessViewRoot);
					if (gameObject2 != null)
					{
						this._singleWinnerGuessView = gameObject2.GetComponent<ChampionshipSingleWinnerGuessView>();
						if (this._singleWinnerGuessView != null)
						{
							this._singleWinnerGuessView.InitView();
						}
					}
				}
				else
				{
					this._singleWinnerGuessView.OnEnableView();
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.funnyGuessViewRoot, true);
				if (this._funnyGuessView == null)
				{
					GameObject gameObject3 = CommonUtility.LoadGameObject(this.funnyGuessViewRoot);
					if (gameObject3 != null)
					{
						this._funnyGuessView = gameObject3.GetComponent<ChampionshipFunnyGuessView>();
						if (this._funnyGuessView != null)
						{
							this._funnyGuessView.InitView();
						}
					}
				}
				else
				{
					this._funnyGuessView.OnEnableView();
				}
			}
		}

		// Token: 0x0600D071 RID: 53361 RVA: 0x003372C7 File Offset: 0x003356C7
		private void OnBetRecordButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipGuessRecordFrame();
		}

		// Token: 0x0600D072 RID: 53362 RVA: 0x003372CE File Offset: 0x003356CE
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipGuessFrame();
		}

		// Token: 0x0600D073 RID: 53363 RVA: 0x003372D8 File Offset: 0x003356D8
		private int GetDefaultSelectGuessTabId()
		{
			int result = 1;
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.ScheduleType >= ChampionshipScheduleTable.eScheduleType.Eight_Select)
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x040079FD RID: 31229
		private int _selectTabId = 1;

		// Token: 0x040079FE RID: 31230
		private ChampionshipFirstWinnerGuessView _firstWinnerGuessView;

		// Token: 0x040079FF RID: 31231
		private ChampionshipSingleWinnerGuessView _singleWinnerGuessView;

		// Token: 0x04007A00 RID: 31232
		private ChampionshipFunnyGuessView _funnyGuessView;

		// Token: 0x04007A01 RID: 31233
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007A02 RID: 31234
		[SerializeField]
		private CommonMoneyControl comMoneyControl;

		// Token: 0x04007A03 RID: 31235
		[SerializeField]
		private Button betRecordButton;

		// Token: 0x04007A04 RID: 31236
		[Space(10f)]
		[Header("Tab")]
		[Space(10f)]
		[SerializeField]
		private ComToggleControlEx tabControlEx;

		// Token: 0x04007A05 RID: 31237
		[SerializeField]
		private GameObject firstWinnerGuessViewRoot;

		// Token: 0x04007A06 RID: 31238
		[SerializeField]
		private GameObject singleWinnerGuessViewRoot;

		// Token: 0x04007A07 RID: 31239
		[SerializeField]
		private GameObject funnyGuessViewRoot;
	}
}
