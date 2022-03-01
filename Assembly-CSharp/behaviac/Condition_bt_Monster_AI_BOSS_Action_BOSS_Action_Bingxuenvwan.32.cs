using System;

namespace behaviac
{
	// Token: 0x02002F95 RID: 12181
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node41 : Condition
	{
		// Token: 0x060147F8 RID: 83960 RVA: 0x0062AC7B File Offset: 0x0062907B
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node41()
		{
			this.opl_p0 = 5532;
		}

		// Token: 0x060147F9 RID: 83961 RVA: 0x0062AC90 File Offset: 0x00629090
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E15C RID: 57692
		private int opl_p0;
	}
}
