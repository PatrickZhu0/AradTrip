using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200142B RID: 5163
	public class ComSelectRoleField : MonoBehaviour
	{
		// Token: 0x0600C83E RID: 51262 RVA: 0x0030912C File Offset: 0x0030752C
		private void Awake()
		{
			this.mBind = base.GetComponent<ComCommonBind>();
			if (this.mBind != null)
			{
				this.name = this.mBind.GetGameObject("name");
				this.level = this.mBind.GetGameObject("level");
				this.job = this.mBind.GetGameObject("job");
				this.avatar = this.mBind.GetGameObject("avatar");
				this.imgAdd = this.mBind.GetGameObject("imgAdd");
				this.imgDisSelect = this.mBind.GetGameObject("imgDisSelect");
				this.imgSelect = this.mBind.GetGameObject("imgSelect");
				this.imgDi = this.mBind.GetGameObject("imgDi");
				this.goBookingActivity = this.mBind.GetGameObject("bookingActivity");
				this.mOldPlayer = this.mBind.GetGameObject("OldPlayer");
				this.like = this.mBind.GetGameObject("Like");
				this.mFieldRoot = this.mBind.GetCom<ComSelectRoleFieldExtendTag>("FieldRoot");
				this.mFieldRoot.CustomActive(true);
			}
		}

		// Token: 0x0600C83F RID: 51263 RVA: 0x0030926C File Offset: 0x0030766C
		private void OnDestroy()
		{
			this.mBind = null;
			this.name = null;
			this.level = null;
			this.job = null;
			this.avatar = null;
			this.imgAdd = null;
			this.imgDisSelect = null;
			this.imgSelect = null;
			this.imgDi = null;
			this.goBookingActivity = null;
			this.mOldPlayer = null;
			this.like = null;
			this.mFieldRoot = null;
			this.fieldState = RoleSelectFieldState.Default;
			this.hasNewTagShowed = false;
		}

		// Token: 0x0600C840 RID: 51264 RVA: 0x003092E4 File Offset: 0x003076E4
		private void _SetDefaultStateShow(bool bNone = false)
		{
			this.name.CustomActive(false);
			this.level.CustomActive(false);
			this.job.CustomActive(false);
			this.avatar.CustomActive(false);
			this.imgAdd.CustomActive(true);
			this.imgDisSelect.CustomActive(true);
			this.imgSelect.CustomActive(false);
			this.imgDi.CustomActive(!bNone);
			this.goBookingActivity.CustomActive(false);
			this.mOldPlayer.CustomActive(false);
			this.like.CustomActive(false);
		}

		// Token: 0x0600C841 RID: 51265 RVA: 0x00309378 File Offset: 0x00307778
		private void _SetBaseHasRoleStateShow()
		{
			this.name.CustomActive(true);
			this.level.CustomActive(true);
			this.job.CustomActive(true);
			this.avatar.CustomActive(true);
			this.imgAdd.CustomActive(false);
			this.imgDisSelect.CustomActive(true);
			this.imgSelect.CustomActive(true);
			this.imgDi.CustomActive(false);
			this.goBookingActivity.CustomActive(false);
			this.mOldPlayer.CustomActive(false);
			this.like.CustomActive(false);
		}

		// Token: 0x0600C842 RID: 51266 RVA: 0x00309409 File Offset: 0x00307809
		public void SetNoneStateShow()
		{
			this._SetDefaultStateShow(true);
			if (this.mFieldRoot != null)
			{
				this.mFieldRoot.SetUnlockShow();
			}
		}

		// Token: 0x0600C843 RID: 51267 RVA: 0x0030942E File Offset: 0x0030782E
		public void SetDefaultStateShow()
		{
			this._SetDefaultStateShow(false);
			if (this.mFieldRoot != null)
			{
				this.mFieldRoot.SetUnlockShow();
			}
		}

		// Token: 0x0600C844 RID: 51268 RVA: 0x00309453 File Offset: 0x00307853
		public void SetBaseHasRoleStateShow()
		{
			this._SetBaseHasRoleStateShow();
			if (this.mFieldRoot != null)
			{
				this.mFieldRoot.SetUnlockShow();
			}
		}

		// Token: 0x0600C845 RID: 51269 RVA: 0x00309477 File Offset: 0x00307877
		public void SetNewUnlockHasRoleStateShow()
		{
			this._SetBaseHasRoleStateShow();
			if (this.mFieldRoot != null)
			{
				if (!this.hasNewTagShowed)
				{
					this.mFieldRoot.SetNewUnlockTagShow();
				}
				this.hasNewTagShowed = true;
			}
		}

		// Token: 0x0600C846 RID: 51270 RVA: 0x003094AD File Offset: 0x003078AD
		public void SetNewUnlockNoRoleStateShow()
		{
			this._SetDefaultStateShow(false);
			if (this.mFieldRoot != null)
			{
				if (!this.hasNewTagShowed)
				{
					this.mFieldRoot.SetNewUnlockTotalShow();
				}
				this.hasNewTagShowed = true;
			}
		}

		// Token: 0x0600C847 RID: 51271 RVA: 0x003094E4 File Offset: 0x003078E4
		public void SetLockHasRoleStateShow()
		{
			this._SetBaseHasRoleStateShow();
			if (this.mFieldRoot != null)
			{
				this.mFieldRoot.SetLockTagShow();
			}
		}

		// Token: 0x0600C848 RID: 51272 RVA: 0x00309508 File Offset: 0x00307908
		public void SetLockNoRoleStateShow()
		{
			this._SetDefaultStateShow(false);
			if (this.mFieldRoot != null)
			{
				this.mFieldRoot.SetLockShow();
			}
		}

		// Token: 0x0600C849 RID: 51273 RVA: 0x0030952D File Offset: 0x0030792D
		public void SetRoleSelectFieldState(RoleSelectFieldState state)
		{
			this.fieldState = state;
		}

		// Token: 0x0600C84A RID: 51274 RVA: 0x00309536 File Offset: 0x00307936
		public RoleSelectFieldState GetRoleSelectFieldState()
		{
			return this.fieldState;
		}

		// Token: 0x04007352 RID: 29522
		private RoleSelectFieldState fieldState = RoleSelectFieldState.Default;

		// Token: 0x04007353 RID: 29523
		private bool hasNewTagShowed;

		// Token: 0x04007354 RID: 29524
		private ComCommonBind mBind;

		// Token: 0x04007355 RID: 29525
		private GameObject name;

		// Token: 0x04007356 RID: 29526
		private GameObject level;

		// Token: 0x04007357 RID: 29527
		private GameObject job;

		// Token: 0x04007358 RID: 29528
		private GameObject avatar;

		// Token: 0x04007359 RID: 29529
		private GameObject imgAdd;

		// Token: 0x0400735A RID: 29530
		private GameObject imgDisSelect;

		// Token: 0x0400735B RID: 29531
		private GameObject imgSelect;

		// Token: 0x0400735C RID: 29532
		private GameObject imgDi;

		// Token: 0x0400735D RID: 29533
		private GameObject goBookingActivity;

		// Token: 0x0400735E RID: 29534
		private GameObject mOldPlayer;

		// Token: 0x0400735F RID: 29535
		private GameObject like;

		// Token: 0x04007360 RID: 29536
		private ComSelectRoleFieldExtendTag mFieldRoot;
	}
}
