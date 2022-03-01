using System;

namespace behaviac
{
	// Token: 0x02002F14 RID: 12052
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node23 : Condition
	{
		// Token: 0x060146FF RID: 83711 RVA: 0x00625B57 File Offset: 0x00623F57
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node23()
		{
			this.opl_p0 = 11000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014700 RID: 83712 RVA: 0x00625B8C File Offset: 0x00623F8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E075 RID: 57461
		private int opl_p0;

		// Token: 0x0400E076 RID: 57462
		private int opl_p1;

		// Token: 0x0400E077 RID: 57463
		private int opl_p2;

		// Token: 0x0400E078 RID: 57464
		private int opl_p3;
	}
}
