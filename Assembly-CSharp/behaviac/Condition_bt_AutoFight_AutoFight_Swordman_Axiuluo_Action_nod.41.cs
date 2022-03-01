using System;

namespace behaviac
{
	// Token: 0x020028CD RID: 10445
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node60 : Condition
	{
		// Token: 0x06013AD4 RID: 80596 RVA: 0x005DFF26 File Offset: 0x005DE326
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node60()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013AD5 RID: 80597 RVA: 0x005DFF3C File Offset: 0x005DE33C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D534 RID: 54580
		private float opl_p0;
	}
}
