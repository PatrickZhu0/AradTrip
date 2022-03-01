using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014EB RID: 5355
	public class ChampionshipFightRaceView : MonoBehaviour
	{
		// Token: 0x0600CFC8 RID: 53192 RVA: 0x00334899 File Offset: 0x00332C99
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CFC9 RID: 53193 RVA: 0x003348A1 File Offset: 0x00332CA1
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CFCA RID: 53194 RVA: 0x003348AF File Offset: 0x00332CAF
		private void ClearData()
		{
			this._scheduleId = 0;
			this._comControlDataExList = null;
			this._scheduleTable = null;
			this._fightRaceCommonView = null;
			this._fightRaceFinalView = null;
		}

		// Token: 0x0600CFCB RID: 53195 RVA: 0x003348D4 File Offset: 0x00332CD4
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x0600CFCC RID: 53196 RVA: 0x00334913 File Offset: 0x00332D13
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CFCD RID: 53197 RVA: 0x00334936 File Offset: 0x00332D36
		public void Init(int scheduleId)
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionshipFightRaceData();
			this._scheduleId = scheduleId;
			this._comControlDataExList = ChampionshipUtility.GetComControlDataExInTopScheduleTable(ref this._scheduleId);
			this.InitView();
		}

		// Token: 0x0600CFCE RID: 53198 RVA: 0x00334960 File Offset: 0x00332D60
		private void InitView()
		{
			if (this.comToggleControlEx != null)
			{
				this.comToggleControlEx.InitComToggleControlEx(this._comControlDataExList, new OnComToggleItemExClick(this.OnTabClickAction), new OnComToggleItemExButtonClick(this.OnButtonClickAction));
			}
			this.UpdateFightRaceContent();
		}

		// Token: 0x0600CFCF RID: 53199 RVA: 0x003349AD File Offset: 0x00332DAD
		private void OnTabClickAction(ComControlDataEx comControlDataEx)
		{
			if (comControlDataEx == null)
			{
				return;
			}
			if (comControlDataEx.Id == this._scheduleId)
			{
				return;
			}
			this._scheduleId = comControlDataEx.Id;
			this.UpdateFightRaceContent();
		}

		// Token: 0x0600CFD0 RID: 53200 RVA: 0x003349DC File Offset: 0x00332DDC
		private void OnButtonClickAction(ComControlDataEx comControlDataEx)
		{
			if (comControlDataEx == null)
			{
				return;
			}
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(comControlDataEx.Id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string msgContent = TR.Value("Championship_Fight_Schedule_Not_Open", tableItem.ScheduleName);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600CFD1 RID: 53201 RVA: 0x00334A2C File Offset: 0x00332E2C
		private void UpdateFightRaceContent()
		{
			this._scheduleTable = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(this._scheduleId, string.Empty, string.Empty);
			if (this._scheduleTable == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.fightRaceFinalViewRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.fightRaceCommonViewRoot, false);
			if (this._scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.One_Select)
			{
				CommonUtility.UpdateGameObjectVisible(this.fightRaceFinalViewRoot, true);
				if (this._fightRaceFinalView == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.fightRaceFinalViewRoot);
					if (gameObject != null)
					{
						this._fightRaceFinalView = gameObject.GetComponent<ChampionshipFightRaceFinalView>();
					}
				}
				if (this._fightRaceFinalView != null)
				{
					this._fightRaceFinalView.UpdateView(this._scheduleTable);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.fightRaceCommonViewRoot, true);
				if (this._fightRaceCommonView == null)
				{
					GameObject gameObject2 = CommonUtility.LoadGameObject(this.fightRaceCommonViewRoot);
					if (gameObject2 != null)
					{
						this._fightRaceCommonView = gameObject2.GetComponent<ChampionshipFightRaceCommonView>();
					}
				}
				if (this._fightRaceCommonView != null)
				{
					this._fightRaceCommonView.UpdateView(this._scheduleTable);
				}
			}
		}

		// Token: 0x0600CFD2 RID: 53202 RVA: 0x00334B5A File Offset: 0x00332F5A
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipFightRaceFrame();
		}

		// Token: 0x04007990 RID: 31120
		private int _scheduleId;

		// Token: 0x04007991 RID: 31121
		private List<ComControlDataEx> _comControlDataExList;

		// Token: 0x04007992 RID: 31122
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007993 RID: 31123
		private ChampionshipFightRaceCommonView _fightRaceCommonView;

		// Token: 0x04007994 RID: 31124
		private ChampionshipFightRaceFinalView _fightRaceFinalView;

		// Token: 0x04007995 RID: 31125
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007996 RID: 31126
		[Space(10f)]
		[Header("ComToggleControl")]
		[Space(10f)]
		[SerializeField]
		private ComToggleControlEx comToggleControlEx;

		// Token: 0x04007997 RID: 31127
		[Space(10f)]
		[Header("ViewRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject fightRaceCommonViewRoot;

		// Token: 0x04007998 RID: 31128
		[SerializeField]
		private GameObject fightRaceFinalViewRoot;
	}
}
