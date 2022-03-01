using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001098 RID: 4248
	public class ComboSkipFrame : ClientFrame
	{
		// Token: 0x0600A00C RID: 40972 RVA: 0x00201973 File Offset: 0x001FFD73
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/ComboSkipFrame";
		}

		// Token: 0x0600A00D RID: 40973 RVA: 0x0020197C File Offset: 0x001FFD7C
		protected override void _bindExUI()
		{
			base._bindExUI();
			this.skipBtn = this.mBind.GetCom<Button>("cancel");
			this.needBtn = this.mBind.GetCom<Button>("ok");
			this.skipBtn.onClick.RemoveAllListeners();
			this.skipBtn.onClick.AddListener(new UnityAction(this.Skip));
			this.needBtn.onClick.RemoveAllListeners();
			this.needBtn.onClick.AddListener(new UnityAction(this.WatchDemonstration));
		}

		// Token: 0x0600A00E RID: 40974 RVA: 0x00201A13 File Offset: 0x001FFE13
		private void WatchDemonstration()
		{
			base.Close(false);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(Singleton<SkillComboControl>.instance.StartCastSkill());
		}

		// Token: 0x0600A00F RID: 40975 RVA: 0x00201A31 File Offset: 0x001FFE31
		private void Skip()
		{
			base.Close(false);
			Singleton<SkillComboControl>.instance.hasPassed = true;
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(Singleton<SkillComboControl>.instance.StartCastSkill());
		}

		// Token: 0x040058AC RID: 22700
		private Button skipBtn;

		// Token: 0x040058AD RID: 22701
		private Button needBtn;
	}
}
