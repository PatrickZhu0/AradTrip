using System;

namespace behaviac
{
	// Token: 0x02003001 RID: 12289
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node22 : Condition
	{
		// Token: 0x060148CC RID: 84172 RVA: 0x0062F803 File Offset: 0x0062DC03
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060148CD RID: 84173 RVA: 0x0062F838 File Offset: 0x0062DC38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E229 RID: 57897
		private int opl_p0;

		// Token: 0x0400E22A RID: 57898
		private int opl_p1;

		// Token: 0x0400E22B RID: 57899
		private int opl_p2;

		// Token: 0x0400E22C RID: 57900
		private int opl_p3;
	}
}
