using System;

namespace behaviac
{
	// Token: 0x0200247F RID: 9343
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node7 : Condition
	{
		// Token: 0x0601324C RID: 78412 RVA: 0x005AE67D File Offset: 0x005ACA7D
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node7()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x0601324D RID: 78413 RVA: 0x005AE69C File Offset: 0x005ACA9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC69 RID: 52329
		private BE_Target opl_p0;

		// Token: 0x0400CC6A RID: 52330
		private BE_Equal opl_p1;

		// Token: 0x0400CC6B RID: 52331
		private BE_State opl_p2;
	}
}
