using System;

namespace behaviac
{
	// Token: 0x020040C1 RID: 16577
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node17 : Condition
	{
		// Token: 0x060168DA RID: 92378 RVA: 0x006D43F7 File Offset: 0x006D27F7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node17()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x060168DB RID: 92379 RVA: 0x006D442C File Offset: 0x006D282C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010120 RID: 65824
		private int opl_p0;

		// Token: 0x04010121 RID: 65825
		private int opl_p1;

		// Token: 0x04010122 RID: 65826
		private int opl_p2;

		// Token: 0x04010123 RID: 65827
		private int opl_p3;
	}
}
