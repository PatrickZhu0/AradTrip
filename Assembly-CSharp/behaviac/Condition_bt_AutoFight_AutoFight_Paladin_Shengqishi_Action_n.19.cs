using System;

namespace behaviac
{
	// Token: 0x0200282B RID: 10283
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node18 : Condition
	{
		// Token: 0x06013994 RID: 80276 RVA: 0x005D8F02 File Offset: 0x005D7302
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node18()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 4500;
			this.opl_p2 = 4500;
			this.opl_p3 = 4500;
		}

		// Token: 0x06013995 RID: 80277 RVA: 0x005D8F38 File Offset: 0x005D7338
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3EC RID: 54252
		private int opl_p0;

		// Token: 0x0400D3ED RID: 54253
		private int opl_p1;

		// Token: 0x0400D3EE RID: 54254
		private int opl_p2;

		// Token: 0x0400D3EF RID: 54255
		private int opl_p3;
	}
}
