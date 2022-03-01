using System;

namespace behaviac
{
	// Token: 0x02002927 RID: 10535
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node54 : Condition
	{
		// Token: 0x06013B84 RID: 80772 RVA: 0x005E49C9 File Offset: 0x005E2DC9
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node54()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B85 RID: 80773 RVA: 0x005E49DC File Offset: 0x005E2DDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5EB RID: 54763
		private float opl_p0;
	}
}
