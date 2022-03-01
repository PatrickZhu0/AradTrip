using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E2 RID: 5346
	public class ChampionshipFinalWinnerView : MonoBehaviour
	{
		// Token: 0x0600CF70 RID: 53104 RVA: 0x00333253 File Offset: 0x00331653
		private void Awake()
		{
			if (this.fightRaceButton != null)
			{
				this.fightRaceButton.onClick.RemoveAllListeners();
				this.fightRaceButton.onClick.AddListener(new UnityAction(this.OnFightRaceButtonClick));
			}
		}

		// Token: 0x0600CF71 RID: 53105 RVA: 0x00333292 File Offset: 0x00331692
		private void OnDestroy()
		{
			if (this.fightRaceButton != null)
			{
				this.fightRaceButton.onClick.RemoveAllListeners();
			}
			this._showFinalWinnerDataModel = null;
		}

		// Token: 0x0600CF72 RID: 53106 RVA: 0x003332BC File Offset: 0x003316BC
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
		}

		// Token: 0x0600CF73 RID: 53107 RVA: 0x003332D9 File Offset: 0x003316D9
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
		}

		// Token: 0x0600CF74 RID: 53108 RVA: 0x003332F8 File Offset: 0x003316F8
		public void InitFinalWinnerView()
		{
			this.InitFinalWinnerTitle();
			this.InitBigRewardControl();
			ChampionshipTopPlayerDataModel finalWinnerDataModel = ChampionshipUtility.GetFinalWinnerDataModel();
			if (finalWinnerDataModel == null)
			{
				DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionshipFightRaceData();
				return;
			}
			this.UpdatePlayerView(finalWinnerDataModel);
		}

		// Token: 0x0600CF75 RID: 53109 RVA: 0x00333330 File Offset: 0x00331730
		private void InitBigRewardControl()
		{
			if (this.bigRewardControl != null)
			{
				int championshipScheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
				this.bigRewardControl.InitControl();
				this.bigRewardControl.SetScheduleId(championshipScheduleId);
			}
		}

		// Token: 0x0600CF76 RID: 53110 RVA: 0x00333370 File Offset: 0x00331770
		private void UpdatePlayerView(ChampionshipTopPlayerDataModel finalWinnerDataModel)
		{
			if (this.finalWinnerPlayerItem == null)
			{
				return;
			}
			if (this._showFinalWinnerDataModel != null)
			{
				return;
			}
			this._showFinalWinnerDataModel = ChampionshipUtility.CreateTopPlayerDataModelByTopPlayerDataModel(finalWinnerDataModel);
			if (this._showFinalWinnerDataModel == null)
			{
				CommonUtility.UpdateGameObjectVisible(this.finalWinnerPlayerItem.gameObject, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.finalWinnerPlayerItem.gameObject, true);
				this.finalWinnerPlayerItem.Init(this._showFinalWinnerDataModel);
			}
		}

		// Token: 0x0600CF77 RID: 53111 RVA: 0x003333EC File Offset: 0x003317EC
		private void InitFinalWinnerTitle()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(130193223, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.Path2.Count < 4)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.finalWinnerTitleRoot, true);
			List<string> list = tableItem.Path2.ToList<string>();
			if (this.spriteAniRenderChangeHao != null)
			{
				string orgPath = list[0];
				string orgName = list[1];
				int count = 0;
				float fScale = 0f;
				if (int.TryParse(list[2], out count) && float.TryParse(list[3], out fScale))
				{
					this.spriteAniRenderChangeHao.Reset(orgPath, orgName, count, fScale, tableItem.ModelPath);
				}
			}
			if (this.spriteAniImage != null)
			{
				this.spriteAniImage.enabled = true;
			}
		}

		// Token: 0x0600CF78 RID: 53112 RVA: 0x003334CC File Offset: 0x003318CC
		private void OnFightRaceButtonClick()
		{
			int championshipScheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
			ChampionshipUtility.OnOpenChampionshipFightRaceFrame(championshipScheduleId);
		}

		// Token: 0x0600CF79 RID: 53113 RVA: 0x003334EC File Offset: 0x003318EC
		private void OnReceiveChampionshipFightRaceAllGroupMessage(UIEvent uiEvent)
		{
			if (!ChampionshipUtility.IsInChampionshipEndShow())
			{
				return;
			}
			ChampionshipTopPlayerDataModel finalWinnerDataModel = ChampionshipUtility.GetFinalWinnerDataModel();
			this.UpdatePlayerView(finalWinnerDataModel);
		}

		// Token: 0x04007955 RID: 31061
		private ChampionshipTopPlayerDataModel _showFinalWinnerDataModel;

		// Token: 0x04007956 RID: 31062
		[Space(10f)]
		[Header("FightRaceButton")]
		[Space(10f)]
		[SerializeField]
		private Button fightRaceButton;

		// Token: 0x04007957 RID: 31063
		[Space(10f)]
		[Header("PlayerItem")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem finalWinnerPlayerItem;

		// Token: 0x04007958 RID: 31064
		[Space(10f)]
		[Header("PlayerTitle")]
		[Space(10f)]
		[SerializeField]
		private GameObject finalWinnerTitleRoot;

		// Token: 0x04007959 RID: 31065
		[SerializeField]
		private SpriteAniRenderChenghao spriteAniRenderChangeHao;

		// Token: 0x0400795A RID: 31066
		[SerializeField]
		private Image spriteAniImage;

		// Token: 0x0400795B RID: 31067
		[Space(10f)]
		[Header("BigRewardPreviewControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipBigRewardControl bigRewardControl;
	}
}
