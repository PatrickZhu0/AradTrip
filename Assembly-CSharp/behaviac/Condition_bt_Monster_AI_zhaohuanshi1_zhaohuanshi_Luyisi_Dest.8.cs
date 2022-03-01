using System;

namespace behaviac
{
	// Token: 0x02004090 RID: 16528
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node17 : Condition
	{
		// Token: 0x0601687C RID: 92284 RVA: 0x006D235F File Offset: 0x006D075F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node17()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x0601687D RID: 92285 RVA: 0x006D2394 File Offset: 0x006D0794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100C5 RID: 65733
		private int opl_p0;

		// Token: 0x040100C6 RID: 65734
		private int opl_p1;

		// Token: 0x040100C7 RID: 65735
		private int opl_p2;

		// Token: 0x040100C8 RID: 65736
		private int opl_p3;
	}
}
