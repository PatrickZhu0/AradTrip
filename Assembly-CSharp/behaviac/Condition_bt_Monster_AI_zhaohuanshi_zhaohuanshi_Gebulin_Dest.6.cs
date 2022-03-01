using System;

namespace behaviac
{
	// Token: 0x02003FC5 RID: 16325
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node14 : Condition
	{
		// Token: 0x060166F3 RID: 91891 RVA: 0x006C9BD7 File Offset: 0x006C7FD7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node14()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060166F4 RID: 91892 RVA: 0x006C9C0C File Offset: 0x006C800C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF44 RID: 65348
		private int opl_p0;

		// Token: 0x0400FF45 RID: 65349
		private int opl_p1;

		// Token: 0x0400FF46 RID: 65350
		private int opl_p2;

		// Token: 0x0400FF47 RID: 65351
		private int opl_p3;
	}
}
