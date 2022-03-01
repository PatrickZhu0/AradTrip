using System;

namespace behaviac
{
	// Token: 0x02004068 RID: 16488
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node6 : Condition
	{
		// Token: 0x0601682E RID: 92206 RVA: 0x006D0BDB File Offset: 0x006CEFDB
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601682F RID: 92207 RVA: 0x006D0C10 File Offset: 0x006CF010
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010077 RID: 65655
		private int opl_p0;

		// Token: 0x04010078 RID: 65656
		private int opl_p1;

		// Token: 0x04010079 RID: 65657
		private int opl_p2;

		// Token: 0x0401007A RID: 65658
		private int opl_p3;
	}
}
