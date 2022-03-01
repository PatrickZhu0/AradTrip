using System;

namespace behaviac
{
	// Token: 0x02003FBF RID: 16319
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node6 : Condition
	{
		// Token: 0x060166E7 RID: 91879 RVA: 0x006C99FF File Offset: 0x006C7DFF
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060166E8 RID: 91880 RVA: 0x006C9A34 File Offset: 0x006C7E34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF38 RID: 65336
		private int opl_p0;

		// Token: 0x0400FF39 RID: 65337
		private int opl_p1;

		// Token: 0x0400FF3A RID: 65338
		private int opl_p2;

		// Token: 0x0400FF3B RID: 65339
		private int opl_p3;
	}
}
