using System;

namespace behaviac
{
	// Token: 0x02002F9F RID: 12191
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node51 : Condition
	{
		// Token: 0x0601480C RID: 83980 RVA: 0x0062B073 File Offset: 0x00629473
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node51()
		{
			this.opl_p0 = 5548;
		}

		// Token: 0x0601480D RID: 83981 RVA: 0x0062B088 File Offset: 0x00629488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E16E RID: 57710
		private int opl_p0;
	}
}
