using System;

namespace behaviac
{
	// Token: 0x02002D17 RID: 11543
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3 : Condition
	{
		// Token: 0x0601431B RID: 82715 RVA: 0x0061119E File Offset: 0x0060F59E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601431C RID: 82716 RVA: 0x006111D4 File Offset: 0x0060F5D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCCD RID: 56525
		private int opl_p0;

		// Token: 0x0400DCCE RID: 56526
		private int opl_p1;

		// Token: 0x0400DCCF RID: 56527
		private int opl_p2;

		// Token: 0x0400DCD0 RID: 56528
		private int opl_p3;
	}
}
