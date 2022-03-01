using System;

namespace behaviac
{
	// Token: 0x02002768 RID: 10088
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node44 : Condition
	{
		// Token: 0x06013811 RID: 79889 RVA: 0x005D00E1 File Offset: 0x005CE4E1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node44()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013812 RID: 79890 RVA: 0x005D00F4 File Offset: 0x005CE4F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D273 RID: 53875
		private float opl_p0;
	}
}
