using System;

namespace behaviac
{
	// Token: 0x02002F8B RID: 12171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node31 : Condition
	{
		// Token: 0x060147E4 RID: 83940 RVA: 0x0062A883 File Offset: 0x00628C83
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node31()
		{
			this.opl_p0 = 5545;
		}

		// Token: 0x060147E5 RID: 83941 RVA: 0x0062A898 File Offset: 0x00628C98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E14A RID: 57674
		private int opl_p0;
	}
}
