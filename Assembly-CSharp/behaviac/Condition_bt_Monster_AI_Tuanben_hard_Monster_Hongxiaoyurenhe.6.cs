using System;

namespace behaviac
{
	// Token: 0x02003D1B RID: 15643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node4 : Condition
	{
		// Token: 0x060161D2 RID: 90578 RVA: 0x006AF56F File Offset: 0x006AD96F
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node4()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060161D3 RID: 90579 RVA: 0x006AF5A4 File Offset: 0x006AD9A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA55 RID: 64085
		private int opl_p0;

		// Token: 0x0400FA56 RID: 64086
		private int opl_p1;

		// Token: 0x0400FA57 RID: 64087
		private int opl_p2;

		// Token: 0x0400FA58 RID: 64088
		private int opl_p3;
	}
}
