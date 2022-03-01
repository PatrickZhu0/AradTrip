using System;

namespace behaviac
{
	// Token: 0x02002923 RID: 10531
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node76 : Condition
	{
		// Token: 0x06013B7C RID: 80764 RVA: 0x005E4815 File Offset: 0x005E2C15
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node76()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013B7D RID: 80765 RVA: 0x005E4828 File Offset: 0x005E2C28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5E3 RID: 54755
		private float opl_p0;
	}
}
