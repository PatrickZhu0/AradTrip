using System;

namespace behaviac
{
	// Token: 0x02002E50 RID: 11856
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node172 : Condition
	{
		// Token: 0x0601457D RID: 83325 RVA: 0x0061B452 File Offset: 0x00619852
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node172()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1800;
			this.opl_p2 = 1200;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601457E RID: 83326 RVA: 0x0061B488 File Offset: 0x00619888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF0E RID: 57102
		private int opl_p0;

		// Token: 0x0400DF0F RID: 57103
		private int opl_p1;

		// Token: 0x0400DF10 RID: 57104
		private int opl_p2;

		// Token: 0x0400DF11 RID: 57105
		private int opl_p3;
	}
}
