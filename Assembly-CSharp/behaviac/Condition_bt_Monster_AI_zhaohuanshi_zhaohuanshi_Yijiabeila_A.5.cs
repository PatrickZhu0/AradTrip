using System;

namespace behaviac
{
	// Token: 0x02004003 RID: 16387
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node23 : Condition
	{
		// Token: 0x0601676A RID: 92010 RVA: 0x006CC5E7 File Offset: 0x006CA9E7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node23()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601676B RID: 92011 RVA: 0x006CC61C File Offset: 0x006CAA1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFB8 RID: 65464
		private int opl_p0;

		// Token: 0x0400FFB9 RID: 65465
		private int opl_p1;

		// Token: 0x0400FFBA RID: 65466
		private int opl_p2;

		// Token: 0x0400FFBB RID: 65467
		private int opl_p3;
	}
}
