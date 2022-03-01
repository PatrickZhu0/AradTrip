using System;

namespace behaviac
{
	// Token: 0x0200400B RID: 16395
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node28 : Condition
	{
		// Token: 0x0601677A RID: 92026 RVA: 0x006CC94F File Offset: 0x006CAD4F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node28()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1200;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601677B RID: 92027 RVA: 0x006CC984 File Offset: 0x006CAD84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFC8 RID: 65480
		private int opl_p0;

		// Token: 0x0400FFC9 RID: 65481
		private int opl_p1;

		// Token: 0x0400FFCA RID: 65482
		private int opl_p2;

		// Token: 0x0400FFCB RID: 65483
		private int opl_p3;
	}
}
