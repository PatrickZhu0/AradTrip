using System;

namespace behaviac
{
	// Token: 0x0200408D RID: 16525
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node13 : Condition
	{
		// Token: 0x06016876 RID: 92278 RVA: 0x006D2273 File Offset: 0x006D0673
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node13()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x06016877 RID: 92279 RVA: 0x006D22A8 File Offset: 0x006D06A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100BF RID: 65727
		private int opl_p0;

		// Token: 0x040100C0 RID: 65728
		private int opl_p1;

		// Token: 0x040100C1 RID: 65729
		private int opl_p2;

		// Token: 0x040100C2 RID: 65730
		private int opl_p3;
	}
}
