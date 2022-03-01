using System;

namespace behaviac
{
	// Token: 0x02003FF8 RID: 16376
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node5 : Condition
	{
		// Token: 0x06016755 RID: 91989 RVA: 0x006CC00B File Offset: 0x006CA40B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node5()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06016756 RID: 91990 RVA: 0x006CC040 File Offset: 0x006CA440
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFA4 RID: 65444
		private int opl_p0;

		// Token: 0x0400FFA5 RID: 65445
		private int opl_p1;

		// Token: 0x0400FFA6 RID: 65446
		private int opl_p2;

		// Token: 0x0400FFA7 RID: 65447
		private int opl_p3;
	}
}
