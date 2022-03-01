using System;

namespace behaviac
{
	// Token: 0x02002E7F RID: 11903
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node167 : Condition
	{
		// Token: 0x060145DB RID: 83419 RVA: 0x0061C856 File Offset: 0x0061AC56
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node167()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1200;
			this.opl_p2 = 1000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060145DC RID: 83420 RVA: 0x0061C88C File Offset: 0x0061AC8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF66 RID: 57190
		private int opl_p0;

		// Token: 0x0400DF67 RID: 57191
		private int opl_p1;

		// Token: 0x0400DF68 RID: 57192
		private int opl_p2;

		// Token: 0x0400DF69 RID: 57193
		private int opl_p3;
	}
}
