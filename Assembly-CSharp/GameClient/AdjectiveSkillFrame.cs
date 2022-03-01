using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A9A RID: 6810
	public class AdjectiveSkillFrame : ClientFrame
	{
		// Token: 0x06010B92 RID: 68498 RVA: 0x004BE1CD File Offset: 0x004BC5CD
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/AdjectiveSkillFrame";
		}

		// Token: 0x06010B93 RID: 68499 RVA: 0x004BE1D4 File Offset: 0x004BC5D4
		protected override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this.mAdjectiveSkillView.InitAdjectiveSkill();
		}

		// Token: 0x06010B94 RID: 68500 RVA: 0x004BE1E7 File Offset: 0x004BC5E7
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdjectiveSkillTipsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdjectiveSkillTipsFrame>(null, false);
			}
		}

		// Token: 0x06010B95 RID: 68501 RVA: 0x004BE20B File Offset: 0x004BC60B
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x06010B96 RID: 68502 RVA: 0x004BE20D File Offset: 0x004BC60D
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x06010B97 RID: 68503 RVA: 0x004BE210 File Offset: 0x004BC610
		protected override void _bindExUI()
		{
			this.mAdjectiveSkillView = this.mBind.GetCom<AdjectiveSkillView>("AdjectiveSkillView");
			this.mCloseBtn = this.mBind.GetCom<Button>("CloseBtn");
			this.mCloseBtn.SafeAddOnClickListener(new UnityAction(this.OnCloseBtnClick));
		}

		// Token: 0x06010B98 RID: 68504 RVA: 0x004BE260 File Offset: 0x004BC660
		protected override void _unbindExUI()
		{
			this.mAdjectiveSkillView = null;
			this.mCloseBtn.SafeRemoveOnClickListener(new UnityAction(this.OnCloseBtnClick));
			this.mCloseBtn = null;
		}

		// Token: 0x06010B99 RID: 68505 RVA: 0x004BE287 File Offset: 0x004BC687
		private void OnCloseBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdjectiveSkillFrame>(null, false);
		}

		// Token: 0x0400AAFE RID: 43774
		private AdjectiveSkillView mAdjectiveSkillView;

		// Token: 0x0400AAFF RID: 43775
		private Button mCloseBtn;
	}
}
