using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001505 RID: 5381
	public class ChampionshipPlayerItem : MonoBehaviour
	{
		// Token: 0x0600D0E9 RID: 53481 RVA: 0x00338F3E File Offset: 0x0033733E
		private void Awake()
		{
			if (this.playerDetailButton != null)
			{
				this.playerDetailButton.onClick.RemoveAllListeners();
				this.playerDetailButton.onClick.AddListener(new UnityAction(this.OnPlayerDetailButtonClick));
			}
		}

		// Token: 0x0600D0EA RID: 53482 RVA: 0x00338F7D File Offset: 0x0033737D
		private void OnDestroy()
		{
			if (this.playerDetailButton != null)
			{
				this.playerDetailButton.onClick.RemoveAllListeners();
			}
			this._playerDataModel = null;
		}

		// Token: 0x0600D0EB RID: 53483 RVA: 0x00338FA8 File Offset: 0x003373A8
		public void Init(ChampionshipTopPlayerDataModel playerDataModel)
		{
			this._playerDataModel = playerDataModel;
			if (this._playerDataModel == null)
			{
				return;
			}
			if (this.nameLabel != null)
			{
				this.nameLabel.text = this._playerDataModel.Name;
			}
			if (this.serverLabel.text != null)
			{
				this.serverLabel.text = this._playerDataModel.ServerName;
			}
			if (this.professionLabel != null)
			{
				string playerProfessionName = PlayerUtility.GetPlayerProfessionName((int)this._playerDataModel.ProfessionId);
				this.professionLabel.text = playerProfessionName;
			}
			this.UpdatePlayerIconImage();
			this.UpdatePlayerHeadFrameImage();
			this.UpdatePlayerRenderEx();
		}

		// Token: 0x0600D0EC RID: 53484 RVA: 0x00339058 File Offset: 0x00337458
		private void UpdatePlayerIconImage()
		{
			if (this.playerProfessionImage == null)
			{
				return;
			}
			int professionId = (int)this._playerDataModel.ProfessionId;
			string playerProfessionHeadIconPath = PlayerUtility.GetPlayerProfessionHeadIconPath(professionId);
			if (string.IsNullOrEmpty(playerProfessionHeadIconPath))
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.playerProfessionImage, playerProfessionHeadIconPath, true);
		}

		// Token: 0x0600D0ED RID: 53485 RVA: 0x003390A4 File Offset: 0x003374A4
		private void UpdatePlayerHeadFrameImage()
		{
			if (this.playerHeadFrameImage == null)
			{
				return;
			}
			string headPortraitFramePath = HeadPortraitFrameDataManager.GetHeadPortraitFramePath(this._playerDataModel.HeadFrameId);
			if (!string.IsNullOrEmpty(headPortraitFramePath))
			{
				ETCImageLoader.LoadSprite(ref this.playerHeadFrameImage, headPortraitFramePath, true);
			}
		}

		// Token: 0x0600D0EE RID: 53486 RVA: 0x003390F0 File Offset: 0x003374F0
		public void UpdatePlayerRenderEx()
		{
			if (this.geAvatarRenderEx == null)
			{
				return;
			}
			if (this._playerDataModel == null)
			{
				return;
			}
			int professionId = (int)this._playerDataModel.ProfessionId;
			PlayerAvatar playerAvatar = this._playerDataModel.PlayerAvatar;
			PlayerUtility.LoadPlayerAvatarByPlayerAvatar(this.geAvatarRenderEx, professionId, playerAvatar);
		}

		// Token: 0x0600D0EF RID: 53487 RVA: 0x00339140 File Offset: 0x00337540
		public void ResetPlayerRenderEx()
		{
			if (this.geAvatarRenderEx != null)
			{
				this.geAvatarRenderEx.m_Layer = 25;
				this.geAvatarRenderEx.ClearAvatar();
			}
		}

		// Token: 0x0600D0F0 RID: 53488 RVA: 0x0033916C File Offset: 0x0033756C
		private void OnPlayerDetailButtonClick()
		{
			if (this._playerDataModel == null)
			{
				return;
			}
			if (this._playerDataModel.PlayerGuid == 0UL)
			{
				return;
			}
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this._playerDataModel.PlayerGuid, 3U, this._playerDataModel.ZoneId);
		}

		// Token: 0x04007A54 RID: 31316
		private ChampionshipTopPlayerDataModel _playerDataModel;

		// Token: 0x04007A55 RID: 31317
		[Space(10f)]
		[Header("geAvatar")]
		[Space(10f)]
		[SerializeField]
		private GeAvatarRendererEx geAvatarRenderEx;

		// Token: 0x04007A56 RID: 31318
		[Space(10f)]
		[Header("PlayerIcon")]
		[Space(10f)]
		[SerializeField]
		private Image playerProfessionImage;

		// Token: 0x04007A57 RID: 31319
		[SerializeField]
		private Image playerHeadFrameImage;

		// Token: 0x04007A58 RID: 31320
		[Space(10f)]
		[Header("Label")]
		[Space(10f)]
		[SerializeField]
		private Text nameLabel;

		// Token: 0x04007A59 RID: 31321
		[SerializeField]
		private Text serverLabel;

		// Token: 0x04007A5A RID: 31322
		[SerializeField]
		private Text professionLabel;

		// Token: 0x04007A5B RID: 31323
		[Space(10f)]
		[Header("PlayerDetailButton")]
		[Space(10f)]
		[SerializeField]
		private Button playerDetailButton;
	}
}
