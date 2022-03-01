using System;

namespace GameClient
{
	// Token: 0x02001444 RID: 5188
	public class AttackCityMonsterTalkFrame : ClientFrame
	{
		// Token: 0x0600C946 RID: 51526 RVA: 0x0030F0B5 File Offset: 0x0030D4B5
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AttackCityMonster/AttackCityMonsterTalkFrame";
		}

		// Token: 0x0600C947 RID: 51527 RVA: 0x0030F0BC File Offset: 0x0030D4BC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mAttackCityMonsterTalkView != null)
			{
				ulong npcGuid = (ulong)this.userData;
				this.mAttackCityMonsterTalkView.InitData(npcGuid);
			}
		}

		// Token: 0x0600C948 RID: 51528 RVA: 0x0030F0F8 File Offset: 0x0030D4F8
		protected override void _bindExUI()
		{
			this.mAttackCityMonsterTalkView = this.mBind.GetCom<AttackCityMonsterTalkView>("AttackCityMonsterTalkView");
		}

		// Token: 0x0600C949 RID: 51529 RVA: 0x0030F110 File Offset: 0x0030D510
		protected override void _unbindExUI()
		{
			this.mAttackCityMonsterTalkView = null;
		}

		// Token: 0x04007427 RID: 29735
		private AttackCityMonsterTalkView mAttackCityMonsterTalkView;
	}
}
