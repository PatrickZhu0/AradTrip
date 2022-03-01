using System;

namespace behaviac
{
	// Token: 0x02002885 RID: 10373
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node32 : Condition
	{
		// Token: 0x06013A47 RID: 80455 RVA: 0x005DD063 File Offset: 0x005DB463
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node32()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013A48 RID: 80456 RVA: 0x005DD098 File Offset: 0x005DB498
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D49F RID: 54431
		private int opl_p0;

		// Token: 0x0400D4A0 RID: 54432
		private int opl_p1;

		// Token: 0x0400D4A1 RID: 54433
		private int opl_p2;

		// Token: 0x0400D4A2 RID: 54434
		private int opl_p3;
	}
}
