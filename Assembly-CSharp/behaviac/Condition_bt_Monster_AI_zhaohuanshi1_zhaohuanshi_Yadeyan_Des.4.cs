using System;

namespace behaviac
{
	// Token: 0x020040A4 RID: 16548
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node8 : Condition
	{
		// Token: 0x060168A2 RID: 92322 RVA: 0x006D32D3 File Offset: 0x006D16D3
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060168A3 RID: 92323 RVA: 0x006D3308 File Offset: 0x006D1708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100E9 RID: 65769
		private int opl_p0;

		// Token: 0x040100EA RID: 65770
		private int opl_p1;

		// Token: 0x040100EB RID: 65771
		private int opl_p2;

		// Token: 0x040100EC RID: 65772
		private int opl_p3;
	}
}
