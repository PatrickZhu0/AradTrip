using System;

namespace behaviac
{
	// Token: 0x02003F8A RID: 16266
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node8 : Condition
	{
		// Token: 0x0601667F RID: 91775 RVA: 0x006C73A3 File Offset: 0x006C57A3
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06016680 RID: 91776 RVA: 0x006C73D8 File Offset: 0x006C57D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FED2 RID: 65234
		private int opl_p0;

		// Token: 0x0400FED3 RID: 65235
		private int opl_p1;

		// Token: 0x0400FED4 RID: 65236
		private int opl_p2;

		// Token: 0x0400FED5 RID: 65237
		private int opl_p3;
	}
}
