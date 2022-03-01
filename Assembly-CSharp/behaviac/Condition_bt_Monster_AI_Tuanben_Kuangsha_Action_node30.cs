using System;

namespace behaviac
{
	// Token: 0x02003AD9 RID: 15065
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node30 : Condition
	{
		// Token: 0x06015D71 RID: 89457 RVA: 0x00698E57 File Offset: 0x00697257
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node30()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06015D72 RID: 89458 RVA: 0x00698E8C File Offset: 0x0069728C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F67F RID: 63103
		private int opl_p0;

		// Token: 0x0400F680 RID: 63104
		private int opl_p1;

		// Token: 0x0400F681 RID: 63105
		private int opl_p2;

		// Token: 0x0400F682 RID: 63106
		private int opl_p3;
	}
}
