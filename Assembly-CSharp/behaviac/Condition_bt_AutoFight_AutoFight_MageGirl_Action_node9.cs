using System;

namespace behaviac
{
	// Token: 0x02002685 RID: 9861
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node9 : Condition
	{
		// Token: 0x0601364E RID: 79438 RVA: 0x005C6671 File Offset: 0x005C4A71
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node9()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601364F RID: 79439 RVA: 0x005C6684 File Offset: 0x005C4A84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0A3 RID: 53411
		private float opl_p0;
	}
}
