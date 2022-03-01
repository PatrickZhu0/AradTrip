using System;

namespace behaviac
{
	// Token: 0x02002870 RID: 10352
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node24 : Condition
	{
		// Token: 0x06013A1D RID: 80413 RVA: 0x005DC73E File Offset: 0x005DAB3E
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node24()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013A1E RID: 80414 RVA: 0x005DC754 File Offset: 0x005DAB54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D476 RID: 54390
		private float opl_p0;
	}
}
