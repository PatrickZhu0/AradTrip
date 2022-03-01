using System;

namespace behaviac
{
	// Token: 0x02003FDA RID: 16346
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4 : Condition
	{
		// Token: 0x0601671C RID: 91932 RVA: 0x006CA8B7 File Offset: 0x006C8CB7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1200;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601671D RID: 91933 RVA: 0x006CA8EC File Offset: 0x006C8CEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF6D RID: 65389
		private int opl_p0;

		// Token: 0x0400FF6E RID: 65390
		private int opl_p1;

		// Token: 0x0400FF6F RID: 65391
		private int opl_p2;

		// Token: 0x0400FF70 RID: 65392
		private int opl_p3;
	}
}
