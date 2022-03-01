using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C99 RID: 7321
	public class TeamDuplicationBasePlayerItem : MonoBehaviour
	{
		// Token: 0x06011F3B RID: 73531 RVA: 0x0053F529 File Offset: 0x0053D929
		protected virtual void Awake()
		{
		}

		// Token: 0x06011F3C RID: 73532 RVA: 0x0053F52B File Offset: 0x0053D92B
		protected virtual void OnDestroy()
		{
			this.PlayerDataModel = null;
		}

		// Token: 0x06011F3D RID: 73533 RVA: 0x0053F534 File Offset: 0x0053D934
		public virtual void Init(TeamDuplicationPlayerDataModel playerDataModel)
		{
			this.PlayerDataModel = playerDataModel;
			this.InitHead();
		}

		// Token: 0x06011F3E RID: 73534 RVA: 0x0053F544 File Offset: 0x0053D944
		private void InitHead()
		{
			if (this.PlayerDataModel == null || this.PlayerDataModel.Guid == 0UL || this.PlayerDataModel.ProfessionId == 0)
			{
				this.ResetHead();
				return;
			}
			string text = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.PlayerDataModel.ProfessionId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					text = tableItem2.IconPath;
				}
			}
			if (this.headIcon != null && !string.IsNullOrEmpty(text))
			{
				ETCImageLoader.LoadSprite(ref this.headIcon, text, true);
				CommonUtility.UpdateImageVisible(this.headIcon, true);
			}
			string headPortraitFramePath = HeadPortraitFrameDataManager.GetHeadPortraitFramePath(this.PlayerDataModel.HeadFrameId);
			if (this.headFrameIcon != null && !string.IsNullOrEmpty(headPortraitFramePath))
			{
				ETCImageLoader.LoadSprite(ref this.headFrameIcon, headPortraitFramePath, true);
			}
		}

		// Token: 0x06011F3F RID: 73535 RVA: 0x0053F64A File Offset: 0x0053DA4A
		private void ResetHead()
		{
			if (this.headIcon != null)
			{
				this.headIcon.sprite = null;
				this.headIcon.material = null;
			}
			CommonUtility.UpdateImageVisible(this.headIcon, false);
		}

		// Token: 0x06011F40 RID: 73536 RVA: 0x0053F681 File Offset: 0x0053DA81
		public ulong GetPlayerGuid()
		{
			if (this.PlayerDataModel == null)
			{
				return 0UL;
			}
			return this.PlayerDataModel.Guid;
		}

		// Token: 0x0400BB20 RID: 47904
		protected TeamDuplicationPlayerDataModel PlayerDataModel;

		// Token: 0x0400BB21 RID: 47905
		[Space(15f)]
		[Header("HeadIcon")]
		[Space(5f)]
		[SerializeField]
		private Image headIcon;

		// Token: 0x0400BB22 RID: 47906
		[SerializeField]
		private Image headFrameIcon;
	}
}
