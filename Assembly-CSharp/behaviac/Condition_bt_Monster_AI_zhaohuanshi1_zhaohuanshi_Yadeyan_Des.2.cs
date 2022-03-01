using System;

namespace behaviac
{
	// Token: 0x020040A1 RID: 16545
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601689C RID: 92316 RVA: 0x006D31E7 File Offset: 0x006D15E7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node5()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601689D RID: 92317 RVA: 0x006D321C File Offset: 0x006D161C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100E3 RID: 65763
		private int opl_p0;

		// Token: 0x040100E4 RID: 65764
		private int opl_p1;

		// Token: 0x040100E5 RID: 65765
		private int opl_p2;

		// Token: 0x040100E6 RID: 65766
		private int opl_p3;
	}
}
