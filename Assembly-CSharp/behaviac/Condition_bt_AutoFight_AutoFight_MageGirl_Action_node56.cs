using System;

namespace behaviac
{
	// Token: 0x02002695 RID: 9877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node56 : Condition
	{
		// Token: 0x0601366E RID: 79470 RVA: 0x005C6D41 File Offset: 0x005C5141
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node56()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601366F RID: 79471 RVA: 0x005C6D54 File Offset: 0x005C5154
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0C3 RID: 53443
		private float opl_p0;
	}
}
