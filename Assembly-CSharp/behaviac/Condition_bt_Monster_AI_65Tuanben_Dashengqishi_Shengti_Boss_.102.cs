using System;

namespace behaviac
{
	// Token: 0x02002E7C RID: 11900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node163 : Condition
	{
		// Token: 0x060145D5 RID: 83413 RVA: 0x0061C6EA File Offset: 0x0061AAEA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node163()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1500;
		}

		// Token: 0x060145D6 RID: 83414 RVA: 0x0061C720 File Offset: 0x0061AB20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF5F RID: 57183
		private int opl_p0;

		// Token: 0x0400DF60 RID: 57184
		private int opl_p1;

		// Token: 0x0400DF61 RID: 57185
		private int opl_p2;

		// Token: 0x0400DF62 RID: 57186
		private int opl_p3;
	}
}
