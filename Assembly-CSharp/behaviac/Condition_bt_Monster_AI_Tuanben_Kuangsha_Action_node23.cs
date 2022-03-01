using System;

namespace behaviac
{
	// Token: 0x02003AD4 RID: 15060
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node23 : Condition
	{
		// Token: 0x06015D67 RID: 89447 RVA: 0x00698C43 File Offset: 0x00697043
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node23()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015D68 RID: 89448 RVA: 0x00698C78 File Offset: 0x00697078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F674 RID: 63092
		private int opl_p0;

		// Token: 0x0400F675 RID: 63093
		private int opl_p1;

		// Token: 0x0400F676 RID: 63094
		private int opl_p2;

		// Token: 0x0400F677 RID: 63095
		private int opl_p3;
	}
}
