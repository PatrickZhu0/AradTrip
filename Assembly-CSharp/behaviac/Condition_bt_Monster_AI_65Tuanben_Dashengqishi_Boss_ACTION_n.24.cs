using System;

namespace behaviac
{
	// Token: 0x02002DAC RID: 11692
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node6 : Condition
	{
		// Token: 0x06014439 RID: 83001 RVA: 0x006162D2 File Offset: 0x006146D2
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node6()
		{
			this.opl_p0 = 9000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601443A RID: 83002 RVA: 0x00616308 File Offset: 0x00614708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDFE RID: 56830
		private int opl_p0;

		// Token: 0x0400DDFF RID: 56831
		private int opl_p1;

		// Token: 0x0400DE00 RID: 56832
		private int opl_p2;

		// Token: 0x0400DE01 RID: 56833
		private int opl_p3;
	}
}
