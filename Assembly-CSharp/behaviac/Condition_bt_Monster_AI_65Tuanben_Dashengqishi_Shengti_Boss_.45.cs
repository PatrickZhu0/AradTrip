using System;

namespace behaviac
{
	// Token: 0x02002E1A RID: 11802
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node129 : Condition
	{
		// Token: 0x06014511 RID: 83217 RVA: 0x00619F2E File Offset: 0x0061832E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node129()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1800;
			this.opl_p2 = 1200;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014512 RID: 83218 RVA: 0x00619F64 File Offset: 0x00618364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEB6 RID: 57014
		private int opl_p0;

		// Token: 0x0400DEB7 RID: 57015
		private int opl_p1;

		// Token: 0x0400DEB8 RID: 57016
		private int opl_p2;

		// Token: 0x0400DEB9 RID: 57017
		private int opl_p3;
	}
}
