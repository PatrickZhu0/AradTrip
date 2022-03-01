using System;

namespace behaviac
{
	// Token: 0x02002C7D RID: 11389
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node3 : Condition
	{
		// Token: 0x060141F2 RID: 82418 RVA: 0x0060B2FF File Offset: 0x006096FF
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node3()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x060141F3 RID: 82419 RVA: 0x0060B334 File Offset: 0x00609734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBB6 RID: 56246
		private int opl_p0;

		// Token: 0x0400DBB7 RID: 56247
		private int opl_p1;

		// Token: 0x0400DBB8 RID: 56248
		private int opl_p2;

		// Token: 0x0400DBB9 RID: 56249
		private int opl_p3;
	}
}
