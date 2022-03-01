using System;

namespace behaviac
{
	// Token: 0x02003FE1 RID: 16353
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node9 : Condition
	{
		// Token: 0x06016729 RID: 91945 RVA: 0x006CAFAB File Offset: 0x006C93AB
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601672A RID: 91946 RVA: 0x006CAFE0 File Offset: 0x006C93E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF7A RID: 65402
		private int opl_p0;

		// Token: 0x0400FF7B RID: 65403
		private int opl_p1;

		// Token: 0x0400FF7C RID: 65404
		private int opl_p2;

		// Token: 0x0400FF7D RID: 65405
		private int opl_p3;
	}
}
