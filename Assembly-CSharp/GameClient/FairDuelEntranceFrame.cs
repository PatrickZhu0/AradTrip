using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200135E RID: 4958
	public class FairDuelEntranceFrame : ClientFrame
	{
		// Token: 0x0600C049 RID: 49225 RVA: 0x002D52A5 File Offset: 0x002D36A5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FairDuel/FairDuelEntranceFrame";
		}

		// Token: 0x0600C04A RID: 49226 RVA: 0x002D52AC File Offset: 0x002D36AC
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.mRoomData = (PkWaitingRoomData)this.userData;
			}
		}

		// Token: 0x0600C04B RID: 49227 RVA: 0x002D52CA File Offset: 0x002D36CA
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600C04C RID: 49228 RVA: 0x002D52CC File Offset: 0x002D36CC
		protected override void _bindExUI()
		{
			this.mCloseBtn = this.mBind.GetCom<Button>("Close");
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseBtnClick));
			}
			this.mHelpBtn = this.mBind.GetCom<Button>("Help");
			if (this.mHelpBtn != null)
			{
				this.mHelpBtn.onClick.AddListener(new UnityAction(this.OnHelpBtnClick));
			}
			this.mGoBtn = this.mBind.GetCom<Button>("Go");
			if (this.mGoBtn != null)
			{
				this.mGoBtn.onClick.AddListener(new UnityAction(this.OnGoBtnClick));
			}
		}

		// Token: 0x0600C04D RID: 49229 RVA: 0x002D53A4 File Offset: 0x002D37A4
		protected override void _unbindExUI()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this.OnCloseBtnClick));
				this.mCloseBtn = null;
			}
			this.mHelpBtn = this.mBind.GetCom<Button>("Help");
			if (this.mHelpBtn != null)
			{
				this.mHelpBtn.onClick.RemoveListener(new UnityAction(this.OnHelpBtnClick));
				this.mHelpBtn = null;
			}
			this.mGoBtn = this.mBind.GetCom<Button>("Go");
			if (this.mGoBtn != null)
			{
				this.mGoBtn.onClick.RemoveListener(new UnityAction(this.OnGoBtnClick));
				this.mGoBtn = null;
			}
		}

		// Token: 0x0600C04E RID: 49230 RVA: 0x002D547C File Offset: 0x002D387C
		private void OnGoBtnClick()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town!!!");
				return;
			}
			if (this.mRoomData == null)
			{
				Logger.LogError("mRoomData is null");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.mRoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 6033,
				targetDoorID = 0
			}, false));
			this.frameMgr.CloseFrame<FairDuelEntranceFrame>(this, false);
		}

		// Token: 0x0600C04F RID: 49231 RVA: 0x002D5510 File Offset: 0x002D3910
		private void OnHelpBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelHelpFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600C050 RID: 49232 RVA: 0x002D5524 File Offset: 0x002D3924
		private void OnCloseBtnClick()
		{
			this.frameMgr.CloseFrame<FairDuelEntranceFrame>(this, false);
		}

		// Token: 0x04006C95 RID: 27797
		private Button mCloseBtn;

		// Token: 0x04006C96 RID: 27798
		private Button mHelpBtn;

		// Token: 0x04006C97 RID: 27799
		private Button mGoBtn;

		// Token: 0x04006C98 RID: 27800
		private PkWaitingRoomData mRoomData = new PkWaitingRoomData();
	}
}
