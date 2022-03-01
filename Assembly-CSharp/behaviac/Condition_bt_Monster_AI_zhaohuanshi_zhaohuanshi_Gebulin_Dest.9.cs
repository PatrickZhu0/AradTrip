using System;

namespace behaviac
{
	// Token: 0x02003FCA RID: 16330
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node22 : Condition
	{
		// Token: 0x060166FD RID: 91901 RVA: 0x006C9D67 File Offset: 0x006C8167
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node22()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060166FE RID: 91902 RVA: 0x006C9D9C File Offset: 0x006C819C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF4F RID: 65359
		private int opl_p0;

		// Token: 0x0400FF50 RID: 65360
		private int opl_p1;

		// Token: 0x0400FF51 RID: 65361
		private int opl_p2;

		// Token: 0x0400FF52 RID: 65362
		private int opl_p3;
	}
}
