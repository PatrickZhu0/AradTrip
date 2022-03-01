using System;

namespace behaviac
{
	// Token: 0x02004012 RID: 16402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node9 : Condition
	{
		// Token: 0x06016787 RID: 92039 RVA: 0x006CD043 File Offset: 0x006CB443
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06016788 RID: 92040 RVA: 0x006CD078 File Offset: 0x006CB478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFD5 RID: 65493
		private int opl_p0;

		// Token: 0x0400FFD6 RID: 65494
		private int opl_p1;

		// Token: 0x0400FFD7 RID: 65495
		private int opl_p2;

		// Token: 0x0400FFD8 RID: 65496
		private int opl_p3;
	}
}
