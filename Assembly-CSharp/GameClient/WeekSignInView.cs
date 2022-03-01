using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A99 RID: 6809
	public class WeekSignInView : ActivityChargeBaseView
	{
		// Token: 0x06010B87 RID: 68487 RVA: 0x004BE0B3 File Offset: 0x004BC4B3
		protected virtual void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06010B88 RID: 68488 RVA: 0x004BE0BB File Offset: 0x004BC4BB
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06010B89 RID: 68489 RVA: 0x004BE0C9 File Offset: 0x004BC4C9
		private void ClearData()
		{
			this._isAlreadyInit = false;
		}

		// Token: 0x06010B8A RID: 68490 RVA: 0x004BE0D2 File Offset: 0x004BC4D2
		private void OnEnable()
		{
			if (!this._isAlreadyInit)
			{
				this._isAlreadyInit = true;
			}
			else
			{
				this.OnEnableWeekSignIn();
			}
		}

		// Token: 0x06010B8B RID: 68491 RVA: 0x004BE0F1 File Offset: 0x004BC4F1
		private void OnDisable()
		{
		}

		// Token: 0x06010B8C RID: 68492 RVA: 0x004BE0F3 File Offset: 0x004BC4F3
		private void BindEvents()
		{
		}

		// Token: 0x06010B8D RID: 68493 RVA: 0x004BE0F5 File Offset: 0x004BC4F5
		private void UnBindEvents()
		{
		}

		// Token: 0x06010B8E RID: 68494 RVA: 0x004BE0F7 File Offset: 0x004BC4F7
		public override void InitView(int intParam)
		{
			this._weekSignInType = WeekSignInType.ActivityWeekSignIn;
			if (intParam == 1)
			{
				this._weekSignInType = WeekSignInType.NewPlayerWeekSignIn;
			}
			WeekSignInUtility.SetWeekSignInShowRedPointTimeByDailyLogin(this._weekSignInType);
			this.InitWeekSignIn();
		}

		// Token: 0x06010B8F RID: 68495 RVA: 0x004BE120 File Offset: 0x004BC520
		protected void InitWeekSignIn()
		{
			if (this.weekSignInCommonControl != null)
			{
				this.weekSignInCommonControl.InitCommonControl(this._weekSignInType);
			}
			if (this.weekSignInAwardControl != null)
			{
				this.weekSignInAwardControl.InitAwardControl(this._weekSignInType);
			}
		}

		// Token: 0x06010B90 RID: 68496 RVA: 0x004BE174 File Offset: 0x004BC574
		protected void OnEnableWeekSignIn()
		{
			if (this._weekSignInType == WeekSignInType.None)
			{
				return;
			}
			if (this.weekSignInCommonControl != null)
			{
				this.weekSignInCommonControl.OnEnableCommonControl();
			}
			if (this.weekSignInAwardControl != null)
			{
				this.weekSignInAwardControl.OnEnableAwardControl();
			}
		}

		// Token: 0x0400AAFA RID: 43770
		private bool _isAlreadyInit;

		// Token: 0x0400AAFB RID: 43771
		[SerializeField]
		private WeekSignInType _weekSignInType;

		// Token: 0x0400AAFC RID: 43772
		[Space(10f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private WeekSignInCommonControl weekSignInCommonControl;

		// Token: 0x0400AAFD RID: 43773
		[SerializeField]
		private WeekSignInAwardControl weekSignInAwardControl;
	}
}
