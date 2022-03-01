using System;

namespace behaviac
{
	// Token: 0x020027A8 RID: 10152
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node33 : Condition
	{
		// Token: 0x06013890 RID: 80016 RVA: 0x005D2E5D File Offset: 0x005D125D
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013891 RID: 80017 RVA: 0x005D2E70 File Offset: 0x005D1270
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2F1 RID: 54001
		private float opl_p0;
	}
}
