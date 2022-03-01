using System;

namespace behaviac
{
	// Token: 0x020040AC RID: 16556
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node23 : Condition
	{
		// Token: 0x060168B1 RID: 92337 RVA: 0x006D37C3 File Offset: 0x006D1BC3
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node23()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060168B2 RID: 92338 RVA: 0x006D37F8 File Offset: 0x006D1BF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100F7 RID: 65783
		private int opl_p0;

		// Token: 0x040100F8 RID: 65784
		private int opl_p1;

		// Token: 0x040100F9 RID: 65785
		private int opl_p2;

		// Token: 0x040100FA RID: 65786
		private int opl_p3;
	}
}
