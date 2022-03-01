using System;

namespace behaviac
{
	// Token: 0x020027A0 RID: 10144
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node23 : Condition
	{
		// Token: 0x06013880 RID: 80000 RVA: 0x005D2AF5 File Offset: 0x005D0EF5
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node23()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013881 RID: 80001 RVA: 0x005D2B08 File Offset: 0x005D0F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2E1 RID: 53985
		private float opl_p0;
	}
}
