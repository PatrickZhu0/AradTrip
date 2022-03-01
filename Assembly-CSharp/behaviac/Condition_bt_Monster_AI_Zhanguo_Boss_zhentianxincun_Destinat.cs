using System;

namespace behaviac
{
	// Token: 0x02003ED0 RID: 16080
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601651C RID: 91420 RVA: 0x006C08ED File Offset: 0x006BECED
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node5()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601651D RID: 91421 RVA: 0x006C0924 File Offset: 0x006BED24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD4F RID: 64847
		private int opl_p0;

		// Token: 0x0400FD50 RID: 64848
		private int opl_p1;

		// Token: 0x0400FD51 RID: 64849
		private int opl_p2;

		// Token: 0x0400FD52 RID: 64850
		private int opl_p3;
	}
}
