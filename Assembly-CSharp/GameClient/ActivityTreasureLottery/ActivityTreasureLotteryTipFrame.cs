using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E6 RID: 5094
	public sealed class ActivityTreasureLotteryTipFrame : ClientFrame
	{
		// Token: 0x0600C584 RID: 50564 RVA: 0x002F9E95 File Offset: 0x002F8295
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActivityTreasureLottery/ActivityTreasureLotteryTipFrame";
		}

		// Token: 0x0600C585 RID: 50565 RVA: 0x002F9E9C File Offset: 0x002F829C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mEffetKaiShi == null)
			{
				string prefabPath = this.mBind.GetPrefabPath("EffectKaiShi");
				if (prefabPath != null)
				{
					this.mEffetKaiShi = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
				}
				if (this.mEffetKaiShi != null)
				{
					Utility.AttachTo(this.mEffetKaiShi, this.frame, false);
				}
			}
			InvokeMethod.Invoke(0.3f, new UnityAction(this.InitEffectBao));
			bool flag = Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActivityTreasureLotteryDrawFrame>(null);
			bool flag2 = Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActivityTreasureLotteryFrame>(null);
			if (flag2)
			{
				base.SetSiblingIndex(Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ActivityTreasureLotteryFrame).Name).GetSiblingIndex() + 1);
			}
			if (flag)
			{
				base.SetSiblingIndex(Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ActivityTreasureLotteryDrawFrame).Name).GetSiblingIndex() - 1);
			}
			if (!flag2 && !flag)
			{
				base.SetSiblingIndex(this.mComClienFrame.GetZOrder());
			}
		}

		// Token: 0x0600C586 RID: 50566 RVA: 0x002F9FB0 File Offset: 0x002F83B0
		private void InitEffectBao()
		{
			if (this.mEffetKaiShiBao == null)
			{
				string prefabPath = this.mBind.GetPrefabPath("EffectKaiShiBao");
				if (prefabPath != null)
				{
					this.mEffetKaiShiBao = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
					if (this.mEffetKaiShiBao != null)
					{
						Utility.AttachTo(this.mEffetKaiShiBao, this.frame, false);
					}
				}
			}
			else
			{
				this.mEffetKaiShiBao.CustomActive(true);
			}
		}

		// Token: 0x0600C587 RID: 50567 RVA: 0x002FA02C File Offset: 0x002F842C
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mEffetKaiShiBao.CustomActive(false);
		}

		// Token: 0x0600C588 RID: 50568 RVA: 0x002FA040 File Offset: 0x002F8440
		protected override void _bindExUI()
		{
			this.mButtonClose = this.mBind.GetCom<Button>("ButtonClose");
			this.mButtonClose.SafeAddOnClickListener(new UnityAction(this._onButtonCloseButtonClick));
			this.mButtonCheck = this.mBind.GetCom<Button>("ButtonCheck");
			this.mButtonCheck.SafeAddOnClickListener(new UnityAction(this._onButtonCheckButtonClick));
		}

		// Token: 0x0600C589 RID: 50569 RVA: 0x002FA0A7 File Offset: 0x002F84A7
		protected override void _unbindExUI()
		{
			this.mButtonClose.SafeRemoveOnClickListener(new UnityAction(this._onButtonCloseButtonClick));
			this.mButtonClose = null;
			this.mButtonCheck.SafeRemoveOnClickListener(new UnityAction(this._onButtonCheckButtonClick));
			this.mButtonCheck = null;
		}

		// Token: 0x0600C58A RID: 50570 RVA: 0x002FA0E5 File Offset: 0x002F84E5
		private void _onButtonCloseButtonClick()
		{
			DataManager<ActivityTreasureLotteryDataManager>.GetInstance().DequeueDrawLottery();
			if (DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetDrawLotteryCount() > 0)
			{
				this.ReOpen();
			}
			else
			{
				base.Close(false);
			}
		}

		// Token: 0x0600C58B RID: 50571 RVA: 0x002FA114 File Offset: 0x002F8514
		private void _onButtonCheckButtonClick()
		{
			if (DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetDrawLotteryCount() > 1)
			{
				this.ReOpen();
			}
			else
			{
				base.Close(false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityTreasureLotteryDrawFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600C58C RID: 50572 RVA: 0x002FA14A File Offset: 0x002F854A
		private void ReOpen()
		{
			if (this.mEffetKaiShiBao != null)
			{
				this.mEffetKaiShiBao.CustomActive(false);
				this.mEffetKaiShiBao.CustomActive(true);
			}
		}

		// Token: 0x040070D7 RID: 28887
		private GameObject mEffetKaiShi;

		// Token: 0x040070D8 RID: 28888
		private GameObject mEffetKaiShiBao;

		// Token: 0x040070D9 RID: 28889
		private const float DelayTime = 0.3f;

		// Token: 0x040070DA RID: 28890
		private Button mButtonClose;

		// Token: 0x040070DB RID: 28891
		private Button mButtonCheck;
	}
}
