using System;

namespace behaviac
{
	// Token: 0x02002FB6 RID: 12214
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node18 : Condition
	{
		// Token: 0x06014839 RID: 84025 RVA: 0x0062C9AB File Offset: 0x0062ADAB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601483A RID: 84026 RVA: 0x0062C9E0 File Offset: 0x0062ADE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E196 RID: 57750
		private int opl_p0;

		// Token: 0x0400E197 RID: 57751
		private int opl_p1;

		// Token: 0x0400E198 RID: 57752
		private int opl_p2;

		// Token: 0x0400E199 RID: 57753
		private int opl_p3;
	}
}
