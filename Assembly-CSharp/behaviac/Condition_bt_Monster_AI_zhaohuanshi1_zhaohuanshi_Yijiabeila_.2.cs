using System;

namespace behaviac
{
	// Token: 0x020040A8 RID: 16552
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node3 : Condition
	{
		// Token: 0x060168A9 RID: 92329 RVA: 0x006D360F File Offset: 0x006D1A0F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node3()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060168AA RID: 92330 RVA: 0x006D3644 File Offset: 0x006D1A44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100EF RID: 65775
		private int opl_p0;

		// Token: 0x040100F0 RID: 65776
		private int opl_p1;

		// Token: 0x040100F1 RID: 65777
		private int opl_p2;

		// Token: 0x040100F2 RID: 65778
		private int opl_p3;
	}
}
