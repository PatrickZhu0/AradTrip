using System;

namespace behaviac
{
	// Token: 0x02002DA9 RID: 11689
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node2 : Condition
	{
		// Token: 0x06014433 RID: 82995 RVA: 0x00616166 File Offset: 0x00614566
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node2()
		{
			this.opl_p0 = 9000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014434 RID: 82996 RVA: 0x0061619C File Offset: 0x0061459C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDF7 RID: 56823
		private int opl_p0;

		// Token: 0x0400DDF8 RID: 56824
		private int opl_p1;

		// Token: 0x0400DDF9 RID: 56825
		private int opl_p2;

		// Token: 0x0400DDFA RID: 56826
		private int opl_p3;
	}
}
