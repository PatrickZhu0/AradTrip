using System;

namespace behaviac
{
	// Token: 0x020040BB RID: 16571
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node9 : Condition
	{
		// Token: 0x060168CE RID: 92366 RVA: 0x006D421F File Offset: 0x006D261F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060168CF RID: 92367 RVA: 0x006D4254 File Offset: 0x006D2654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010114 RID: 65812
		private int opl_p0;

		// Token: 0x04010115 RID: 65813
		private int opl_p1;

		// Token: 0x04010116 RID: 65814
		private int opl_p2;

		// Token: 0x04010117 RID: 65815
		private int opl_p3;
	}
}
