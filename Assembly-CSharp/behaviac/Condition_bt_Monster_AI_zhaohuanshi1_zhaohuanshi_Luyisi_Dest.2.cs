using System;

namespace behaviac
{
	// Token: 0x02004087 RID: 16519
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node6 : Condition
	{
		// Token: 0x0601686A RID: 92266 RVA: 0x006D209B File Offset: 0x006D049B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601686B RID: 92267 RVA: 0x006D20D0 File Offset: 0x006D04D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100B3 RID: 65715
		private int opl_p0;

		// Token: 0x040100B4 RID: 65716
		private int opl_p1;

		// Token: 0x040100B5 RID: 65717
		private int opl_p2;

		// Token: 0x040100B6 RID: 65718
		private int opl_p3;
	}
}
