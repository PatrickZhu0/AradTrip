using System;

namespace behaviac
{
	// Token: 0x02002890 RID: 10384
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node42 : Condition
	{
		// Token: 0x06013A5D RID: 80477 RVA: 0x005DD5E7 File Offset: 0x005DB9E7
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node42()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013A5E RID: 80478 RVA: 0x005DD61C File Offset: 0x005DBA1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4B6 RID: 54454
		private int opl_p0;

		// Token: 0x0400D4B7 RID: 54455
		private int opl_p1;

		// Token: 0x0400D4B8 RID: 54456
		private int opl_p2;

		// Token: 0x0400D4B9 RID: 54457
		private int opl_p3;
	}
}
