using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014FB RID: 5371
	public class ChampionshipFirstWinnerGuessView : MonoBehaviour
	{
		// Token: 0x0600D075 RID: 53365 RVA: 0x00337330 File Offset: 0x00335730
		private void Awake()
		{
			if (this.playerItemList != null)
			{
				this.playerItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.playerItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPlayerItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.playerItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnPlayerItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.playerItemList;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnPlayerItemRecycle));
			}
		}

		// Token: 0x0600D076 RID: 53366 RVA: 0x003373D0 File Offset: 0x003357D0
		private void OnDestroy()
		{
			if (this.playerItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.playerItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPlayerItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.playerItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnPlayerItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.playerItemList;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnPlayerItemRecycle));
			}
			this.ClearData();
		}

		// Token: 0x0600D077 RID: 53367 RVA: 0x00337469 File Offset: 0x00335869
		private void ClearData()
		{
			this._isFirstWinnerGuessBuild = false;
			this._guessProjectDataModel = null;
			this._selectedGuessOptionId = 0UL;
			this._firstWinnerGuessPlayerDataModelList.Clear();
		}

		// Token: 0x0600D078 RID: 53368 RVA: 0x0033748C File Offset: 0x0033588C
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGuessProjectResMessage));
		}

		// Token: 0x0600D079 RID: 53369 RVA: 0x003374A9 File Offset: 0x003358A9
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGuessProjectResMessage));
		}

		// Token: 0x0600D07A RID: 53370 RVA: 0x003374C6 File Offset: 0x003358C6
		public void InitView()
		{
			this.UpdateContent(false);
		}

		// Token: 0x0600D07B RID: 53371 RVA: 0x003374CF File Offset: 0x003358CF
		public void OnEnableView()
		{
			this.UpdateContent(true);
		}

		// Token: 0x0600D07C RID: 53372 RVA: 0x003374D8 File Offset: 0x003358D8
		private void OnReceiveChampionshipGuessProjectResMessage(UIEvent uiEvent)
		{
			this.UpdateContent(false);
		}

		// Token: 0x0600D07D RID: 53373 RVA: 0x003374E4 File Offset: 0x003358E4
		private void UpdateContent(bool isOnEnable = false)
		{
			if (this._isFirstWinnerGuessBuild)
			{
				if (isOnEnable)
				{
					this.UpdateGuessControlByOnEnable();
				}
				else
				{
					this.UpdateGuessControlByUpdateData();
				}
			}
			else
			{
				this._guessProjectDataModel = ChampionshipUtility.GetChampionshipGuessProjectDataModelByProjectType(GambleType.GT_CHAMPION, 0);
				if (this._guessProjectDataModel != null)
				{
					List<ulong> guessOptionIdList = this._guessProjectDataModel.GuessOptionIdList;
					if (guessOptionIdList != null && guessOptionIdList.Count > 0)
					{
						for (int i = 0; i < guessOptionIdList.Count; i++)
						{
							ulong num = guessOptionIdList[i];
							ChampionshipFirstWinnerGuessPlayerDataModel championshipFirstWinnerGuessPlayerDataModel = new ChampionshipFirstWinnerGuessPlayerDataModel();
							championshipFirstWinnerGuessPlayerDataModel.OptionId = num;
							if (i == 0)
							{
								championshipFirstWinnerGuessPlayerDataModel.IsSelected = true;
								this._selectedGuessOptionId = num;
							}
							else
							{
								championshipFirstWinnerGuessPlayerDataModel.IsSelected = false;
							}
							this._firstWinnerGuessPlayerDataModelList.Add(championshipFirstWinnerGuessPlayerDataModel);
						}
					}
					this._isFirstWinnerGuessBuild = true;
					this.InitPlayerItemList();
					this.InitGuessControl();
				}
			}
		}

		// Token: 0x0600D07E RID: 53374 RVA: 0x003375BC File Offset: 0x003359BC
		private void InitPlayerItemList()
		{
			int count = this._firstWinnerGuessPlayerDataModelList.Count;
			if (this.playerItemList != null)
			{
				this.playerItemList.SetElementAmount(count);
			}
		}

		// Token: 0x0600D07F RID: 53375 RVA: 0x003375F4 File Offset: 0x003359F4
		private void UpdatePlayerItemList()
		{
			for (int i = 0; i < this._firstWinnerGuessPlayerDataModelList.Count; i++)
			{
				ChampionshipFirstWinnerGuessPlayerDataModel championshipFirstWinnerGuessPlayerDataModel = this._firstWinnerGuessPlayerDataModelList[i];
				if (championshipFirstWinnerGuessPlayerDataModel != null)
				{
					if (championshipFirstWinnerGuessPlayerDataModel.OptionId == this._selectedGuessOptionId)
					{
						championshipFirstWinnerGuessPlayerDataModel.IsSelected = true;
					}
					else
					{
						championshipFirstWinnerGuessPlayerDataModel.IsSelected = false;
					}
				}
			}
			if (this.playerItemList != null)
			{
				this.playerItemList.UpdateElement();
			}
		}

		// Token: 0x0600D080 RID: 53376 RVA: 0x00337678 File Offset: 0x00335A78
		private void InitGuessControl()
		{
			if (this.firstWinnerGuessControl == null)
			{
				return;
			}
			if (this._guessProjectDataModel == null || this._guessProjectDataModel.GuessOptionDataModelDictionary == null || !this._guessProjectDataModel.GuessOptionDataModelDictionary.ContainsKey(this._selectedGuessOptionId))
			{
				return;
			}
			ChampionshipGuessOptionDataModel guessOptionDataModel = this._guessProjectDataModel.GuessOptionDataModelDictionary[this._selectedGuessOptionId];
			this.firstWinnerGuessControl.InitControl(this._guessProjectDataModel, guessOptionDataModel);
		}

		// Token: 0x0600D081 RID: 53377 RVA: 0x003376F7 File Offset: 0x00335AF7
		private void UpdateGuessControlByOnEnable()
		{
			if (this.firstWinnerGuessControl == null)
			{
				return;
			}
			this.firstWinnerGuessControl.UpdateControlByOnEnable();
		}

		// Token: 0x0600D082 RID: 53378 RVA: 0x00337716 File Offset: 0x00335B16
		private void UpdateGuessControlByUpdateData()
		{
			if (this.firstWinnerGuessControl == null)
			{
				return;
			}
			this.firstWinnerGuessControl.UpdateControlByUpdateData();
		}

		// Token: 0x0600D083 RID: 53379 RVA: 0x00337738 File Offset: 0x00335B38
		private void OnPlayerItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._firstWinnerGuessPlayerDataModelList == null || this._firstWinnerGuessPlayerDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._firstWinnerGuessPlayerDataModelList.Count)
			{
				return;
			}
			ChampionshipFirstWinnerGuessPlayerDataModel championshipFirstWinnerGuessPlayerDataModel = this._firstWinnerGuessPlayerDataModelList[item.m_index];
			ChampionshipFirstWinnerGuessPlayerItem component = item.GetComponent<ChampionshipFirstWinnerGuessPlayerItem>();
			if (component != null && championshipFirstWinnerGuessPlayerDataModel != null)
			{
				component.InitItem(championshipFirstWinnerGuessPlayerDataModel, new OnFirstWinnerGuessPlayerItemClickAction(this.OnPlayerItemClickedAction));
			}
		}

		// Token: 0x0600D084 RID: 53380 RVA: 0x003377D0 File Offset: 0x00335BD0
		private void OnPlayerItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipFirstWinnerGuessPlayerItem component = item.GetComponent<ChampionshipFirstWinnerGuessPlayerItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D085 RID: 53381 RVA: 0x00337804 File Offset: 0x00335C04
		private void OnPlayerItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipFirstWinnerGuessPlayerItem component = item.GetComponent<ChampionshipFirstWinnerGuessPlayerItem>();
			if (component != null)
			{
				component.UpdateItem();
			}
		}

		// Token: 0x0600D086 RID: 53382 RVA: 0x00337837 File Offset: 0x00335C37
		private void OnPlayerItemClickedAction(ulong optionId)
		{
			if (this._selectedGuessOptionId == optionId)
			{
				return;
			}
			this._selectedGuessOptionId = optionId;
			this.InitGuessControl();
			this.UpdatePlayerItemList();
		}

		// Token: 0x04007A08 RID: 31240
		private bool _isFirstWinnerGuessBuild;

		// Token: 0x04007A09 RID: 31241
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x04007A0A RID: 31242
		private ulong _selectedGuessOptionId;

		// Token: 0x04007A0B RID: 31243
		private List<ChampionshipFirstWinnerGuessPlayerDataModel> _firstWinnerGuessPlayerDataModelList = new List<ChampionshipFirstWinnerGuessPlayerDataModel>();

		// Token: 0x04007A0C RID: 31244
		[Space(10f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipFirstWinnerGuessControl firstWinnerGuessControl;

		// Token: 0x04007A0D RID: 31245
		[SerializeField]
		private ComUIListScriptEx playerItemList;
	}
}
