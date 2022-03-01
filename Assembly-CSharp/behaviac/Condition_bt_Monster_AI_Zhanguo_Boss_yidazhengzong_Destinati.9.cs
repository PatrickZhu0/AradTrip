using System;

namespace behaviac
{
	// Token: 0x02003E99 RID: 16025
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node18 : Condition
	{
		// Token: 0x060164B2 RID: 91314 RVA: 0x006BDBF1 File Offset: 0x006BBFF1
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node18()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164B3 RID: 91315 RVA: 0x006BDC28 File Offset: 0x006BC028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE8 RID: 64744
		private int opl_p0;

		// Token: 0x0400FCE9 RID: 64745
		private int opl_p1;

		// Token: 0x0400FCEA RID: 64746
		private int opl_p2;

		// Token: 0x0400FCEB RID: 64747
		private int opl_p3;
	}
}
