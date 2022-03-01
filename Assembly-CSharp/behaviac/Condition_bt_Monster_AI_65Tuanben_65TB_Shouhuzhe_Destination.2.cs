using System;

namespace behaviac
{
	// Token: 0x02002C7F RID: 11391
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node7 : Condition
	{
		// Token: 0x060141F6 RID: 82422 RVA: 0x0060B3A4 File Offset: 0x006097A4
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node7()
		{
			this.opl_p0 = 12000;
			this.opl_p1 = 12000;
			this.opl_p2 = 12000;
			this.opl_p3 = 12000;
		}

		// Token: 0x060141F7 RID: 82423 RVA: 0x0060B3D8 File Offset: 0x006097D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBBB RID: 56251
		private int opl_p0;

		// Token: 0x0400DBBC RID: 56252
		private int opl_p1;

		// Token: 0x0400DBBD RID: 56253
		private int opl_p2;

		// Token: 0x0400DBBE RID: 56254
		private int opl_p3;
	}
}
