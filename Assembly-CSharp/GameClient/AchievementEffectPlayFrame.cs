using System;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020013C7 RID: 5063
	public class AchievementEffectPlayFrame : ClientFrame
	{
		// Token: 0x0600C480 RID: 50304 RVA: 0x002F3206 File Offset: 0x002F1606
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActiveGroup/AchievementEffectPlayFrame";
		}

		// Token: 0x0600C481 RID: 50305 RVA: 0x002F3210 File Offset: 0x002F1610
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<AchievementEffectPlayFrame>(this, false);
			});
			InvokeMethod.InvokeInterval(this, 0f, 3f, 9999f, new UnityAction(this._TriggerEffect), new UnityAction(this._TriggerEffect), null);
		}

		// Token: 0x0600C482 RID: 50306 RVA: 0x002F3264 File Offset: 0x002F1664
		private void _TriggerEffect()
		{
			if (!DataManager<MissionManager>.GetInstance().HasAchievementItem())
			{
				this.frameMgr.CloseFrame<AchievementEffectPlayFrame>(this, false);
				return;
			}
			base.GetFrame().CustomActive(false);
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(67, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.StartLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				return;
			}
			base.GetFrame().CustomActive(true);
			if (null != this.mComAchievementEffectPlayConfig)
			{
				this.mComAchievementEffectPlayConfig.Play();
			}
		}

		// Token: 0x0600C483 RID: 50307 RVA: 0x002F32F6 File Offset: 0x002F16F6
		protected override void _OnCloseFrame()
		{
			InvokeMethod.RmoveInvokeIntervalCall(this);
		}

		// Token: 0x04006FEA RID: 28650
		[UIControl("", typeof(ComAchievementEffectPlayConfig), 0)]
		private ComAchievementEffectPlayConfig mComAchievementEffectPlayConfig;
	}
}
