using System;

namespace behaviac
{
	// Token: 0x0200406B RID: 16491
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node10 : Condition
	{
		// Token: 0x06016834 RID: 92212 RVA: 0x006D0CC7 File Offset: 0x006CF0C7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06016835 RID: 92213 RVA: 0x006D0CFC File Offset: 0x006CF0FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401007D RID: 65661
		private int opl_p0;

		// Token: 0x0401007E RID: 65662
		private int opl_p1;

		// Token: 0x0401007F RID: 65663
		private int opl_p2;

		// Token: 0x04010080 RID: 65664
		private int opl_p3;
	}
}
