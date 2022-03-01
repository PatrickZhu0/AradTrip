using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C9B RID: 7323
	public class TeamDuplicationTeamCaptainItem : MonoBehaviour
	{
		// Token: 0x06011F50 RID: 73552 RVA: 0x0053FF36 File Offset: 0x0053E336
		private void Awake()
		{
		}

		// Token: 0x06011F51 RID: 73553 RVA: 0x0053FF38 File Offset: 0x0053E338
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationCaptainNotifyMessage));
		}

		// Token: 0x06011F52 RID: 73554 RVA: 0x0053FF55 File Offset: 0x0053E355
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationCaptainNotifyMessage));
		}

		// Token: 0x06011F53 RID: 73555 RVA: 0x0053FF72 File Offset: 0x0053E372
		private void OnDestroy()
		{
			this._captainDataModel = null;
		}

		// Token: 0x06011F54 RID: 73556 RVA: 0x0053FF7B File Offset: 0x0053E37B
		public void Init(TeamDuplicationCaptainDataModel captainDataModel)
		{
			this._captainDataModel = captainDataModel;
			if (this._captainDataModel == null)
			{
				Logger.LogErrorFormat("TeamDuplicationTroopTotalItem Init troopDataModel is null", new object[0]);
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F55 RID: 73557 RVA: 0x0053FFA6 File Offset: 0x0053E3A6
		private void InitItem()
		{
			this.InitCaptainImage();
			this.UpdateCaptainStatus();
			this.UpdateTeamCaptainPlayerItem();
		}

		// Token: 0x06011F56 RID: 73558 RVA: 0x0053FFBC File Offset: 0x0053E3BC
		private void InitCaptainImage()
		{
			if (this.captainIndexImage == null)
			{
				return;
			}
			string path = string.Format("UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Shuzi_{0}", this._captainDataModel.CaptainId);
			ETCImageLoader.LoadSprite(ref this.captainIndexImage, path, true);
		}

		// Token: 0x06011F57 RID: 73559 RVA: 0x00540004 File Offset: 0x0053E404
		private void UpdateCaptainStatus()
		{
			if (this.captainStatusImage == null)
			{
				return;
			}
			string path = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Daiji_Zi";
			TeamCopySquadStatus captainStatus = (TeamCopySquadStatus)this._captainDataModel.CaptainStatus;
			if (captainStatus == TeamCopySquadStatus.TEAM_COPY_SQUAD_STATUS_PREPARE)
			{
				path = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Beizhan_Zi";
			}
			else if (captainStatus == TeamCopySquadStatus.TEAM_COPY_SQUAD_STATUS_BATTLE)
			{
				path = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Zhandou_Zi";
			}
			ETCImageLoader.LoadSprite(ref this.captainStatusImage, path, true);
		}

		// Token: 0x06011F58 RID: 73560 RVA: 0x00540064 File Offset: 0x0053E464
		private void UpdateTeamCaptainPlayerItem()
		{
			if (this.firstPlayerItem != null)
			{
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 0)
				{
					this.firstPlayerItem.Init(this._captainDataModel.PlayerList[0]);
				}
				else
				{
					this.firstPlayerItem.Init(null);
				}
			}
			if (this.secondPlayerItem != null)
			{
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 1)
				{
					this.secondPlayerItem.Init(this._captainDataModel.PlayerList[1]);
				}
				else
				{
					this.secondPlayerItem.Init(null);
				}
			}
			if (this.thirdPlayerItem != null)
			{
				if (this._captainDataModel.PlayerList != null && this._captainDataModel.PlayerList.Count > 2)
				{
					this.thirdPlayerItem.Init(this._captainDataModel.PlayerList[2]);
				}
				else
				{
					this.thirdPlayerItem.Init(null);
				}
			}
		}

		// Token: 0x06011F59 RID: 73561 RVA: 0x005401A0 File Offset: 0x0053E5A0
		private void OnReceiveTeamDuplicationCaptainNotifyMessage(UIEvent uiEvent)
		{
			if (this._captainDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._captainDataModel.CaptainId != num)
			{
				return;
			}
			this.UpdateCaptainStatus();
		}

		// Token: 0x0400BB2C RID: 47916
		private const string captainIndexPath = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Shuzi_{0}";

		// Token: 0x0400BB2D RID: 47917
		private const string captainStatusIdle = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Daiji_Zi";

		// Token: 0x0400BB2E RID: 47918
		private const string captainStatusPrepare = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Beizhan_Zi";

		// Token: 0x0400BB2F RID: 47919
		private const string captainStatusFighting = "UI/Image/Packed/p_UI_Tuanben.png:UI_Tuanben_Zhandou_Zi";

		// Token: 0x0400BB30 RID: 47920
		private TeamDuplicationCaptainDataModel _captainDataModel;

		// Token: 0x0400BB31 RID: 47921
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Image captainIndexImage;

		// Token: 0x0400BB32 RID: 47922
		[SerializeField]
		private Image captainStatusImage;

		// Token: 0x0400BB33 RID: 47923
		[Space(10f)]
		[Header("PlayerItem")]
		[Space(5f)]
		[SerializeField]
		private TeamDuplicationTeamCaptainPlayerItem firstPlayerItem;

		// Token: 0x0400BB34 RID: 47924
		[SerializeField]
		private TeamDuplicationTeamCaptainPlayerItem secondPlayerItem;

		// Token: 0x0400BB35 RID: 47925
		[SerializeField]
		private TeamDuplicationTeamCaptainPlayerItem thirdPlayerItem;
	}
}
