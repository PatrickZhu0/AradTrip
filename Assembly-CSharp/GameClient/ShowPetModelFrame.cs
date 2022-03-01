using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001919 RID: 6425
	internal class ShowPetModelFrame : ClientFrame
	{
		// Token: 0x0600FA1A RID: 64026 RVA: 0x0044764B File Offset: 0x00445A4B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/ShowPetModelFrame";
		}

		// Token: 0x0600FA1B RID: 64027 RVA: 0x00447652 File Offset: 0x00445A52
		protected sealed override void _OnOpenFrame()
		{
			this.iPetId = (int)this.userData;
			this.UpdateActor(this.iPetId);
		}

		// Token: 0x0600FA1C RID: 64028 RVA: 0x00447671 File Offset: 0x00445A71
		protected sealed override void _OnCloseFrame()
		{
			this.iPetId = 0;
			this.mAvatarRenderer.ClearAvatar();
		}

		// Token: 0x0600FA1D RID: 64029 RVA: 0x00447688 File Offset: 0x00445A88
		private void UpdateActor(int iPetID)
		{
			PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>(iPetID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
				{
					iPetID
				});
			}
			else if (Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.ModeID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
				{
					tableItem.ModeID
				});
			}
			else
			{
				PlayerUtility.LoadPetAvatarRenderEx(iPetID, this.mAvatarRenderer, true);
				Vector3 avatarPos = this.mAvatarRenderer.avatarPos;
				avatarPos.y = (float)tableItem.ChangedHeight / 1000f;
				this.mAvatarRenderer.avatarPos = avatarPos;
				Quaternion avatarRoation = this.mAvatarRenderer.avatarRoation;
				this.mAvatarRenderer.avatarRoation = Quaternion.Euler(avatarRoation.x, (float)tableItem.ModelOrientation / 1000f, avatarRoation.z);
				Vector3 avatarScale = this.mAvatarRenderer.avatarScale;
				Vector3 avatarScale2 = this.mAvatarRenderer.avatarScale;
				avatarScale2.y = (avatarScale2.x = (avatarScale2.z = (float)tableItem.PetModelSize / 1000f));
				this.mAvatarRenderer.avatarScale = avatarScale2;
			}
		}

		// Token: 0x0600FA1E RID: 64030 RVA: 0x004477D8 File Offset: 0x00445BD8
		protected sealed override void _bindExUI()
		{
			this.mAvatarRenderer = this.mBind.GetCom<GeAvatarRendererEx>("AvatarRenderer");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0600FA1F RID: 64031 RVA: 0x0044783E File Offset: 0x00445C3E
		protected sealed override void _unbindExUI()
		{
			this.mAvatarRenderer = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x0600FA20 RID: 64032 RVA: 0x0044787B File Offset: 0x00445C7B
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ShowPetModelFrame>(this, false);
		}

		// Token: 0x04009C30 RID: 39984
		private int iPetId;

		// Token: 0x04009C31 RID: 39985
		private GeAvatarRendererEx mAvatarRenderer;

		// Token: 0x04009C32 RID: 39986
		private Button mClose;
	}
}
