using System;

namespace behaviac
{
	// Token: 0x0200408A RID: 16522
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node9 : Condition
	{
		// Token: 0x06016870 RID: 92272 RVA: 0x006D2187 File Offset: 0x006D0587
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06016871 RID: 92273 RVA: 0x006D21BC File Offset: 0x006D05BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100B9 RID: 65721
		private int opl_p0;

		// Token: 0x040100BA RID: 65722
		private int opl_p1;

		// Token: 0x040100BB RID: 65723
		private int opl_p2;

		// Token: 0x040100BC RID: 65724
		private int opl_p3;
	}
}
