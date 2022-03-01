using System;

namespace behaviac
{
	// Token: 0x02002F86 RID: 12166
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node26 : Condition
	{
		// Token: 0x060147DA RID: 83930 RVA: 0x0062A687 File Offset: 0x00628A87
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node26()
		{
			this.opl_p0 = 5534;
		}

		// Token: 0x060147DB RID: 83931 RVA: 0x0062A69C File Offset: 0x00628A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E141 RID: 57665
		private int opl_p0;
	}
}
