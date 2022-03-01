using System;

namespace behaviac
{
	// Token: 0x02002774 RID: 10100
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node70 : Condition
	{
		// Token: 0x06013829 RID: 79913 RVA: 0x005D05FD File Offset: 0x005CE9FD
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node70()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601382A RID: 79914 RVA: 0x005D0610 File Offset: 0x005CEA10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D28B RID: 53899
		private float opl_p0;
	}
}
