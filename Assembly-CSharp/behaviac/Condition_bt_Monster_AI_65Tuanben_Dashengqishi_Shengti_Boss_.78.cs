using System;

namespace behaviac
{
	// Token: 0x02002E53 RID: 11859
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node176 : Condition
	{
		// Token: 0x06014583 RID: 83331 RVA: 0x0061B5BE File Offset: 0x006199BE
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node176()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014584 RID: 83332 RVA: 0x0061B5F4 File Offset: 0x006199F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF15 RID: 57109
		private int opl_p0;

		// Token: 0x0400DF16 RID: 57110
		private int opl_p1;

		// Token: 0x0400DF17 RID: 57111
		private int opl_p2;

		// Token: 0x0400DF18 RID: 57112
		private int opl_p3;
	}
}
