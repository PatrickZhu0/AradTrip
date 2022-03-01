using System;

namespace behaviac
{
	// Token: 0x02002833 RID: 10291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node33 : Condition
	{
		// Token: 0x060139A4 RID: 80292 RVA: 0x005D926A File Offset: 0x005D766A
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node33()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060139A5 RID: 80293 RVA: 0x005D92A0 File Offset: 0x005D76A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3FC RID: 54268
		private int opl_p0;

		// Token: 0x0400D3FD RID: 54269
		private int opl_p1;

		// Token: 0x0400D3FE RID: 54270
		private int opl_p2;

		// Token: 0x0400D3FF RID: 54271
		private int opl_p3;
	}
}
