using System;

namespace behaviac
{
	// Token: 0x02003FC8 RID: 16328
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node18 : Condition
	{
		// Token: 0x060166F9 RID: 91897 RVA: 0x006C9CC3 File Offset: 0x006C80C3
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060166FA RID: 91898 RVA: 0x006C9CF8 File Offset: 0x006C80F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF4A RID: 65354
		private int opl_p0;

		// Token: 0x0400FF4B RID: 65355
		private int opl_p1;

		// Token: 0x0400FF4C RID: 65356
		private int opl_p2;

		// Token: 0x0400FF4D RID: 65357
		private int opl_p3;
	}
}
