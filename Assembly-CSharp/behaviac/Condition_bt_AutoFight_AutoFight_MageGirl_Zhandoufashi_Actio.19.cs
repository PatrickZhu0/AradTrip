using System;

namespace behaviac
{
	// Token: 0x02002719 RID: 10009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node34 : Condition
	{
		// Token: 0x06013774 RID: 79732 RVA: 0x005CCA19 File Offset: 0x005CAE19
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node34()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013775 RID: 79733 RVA: 0x005CCA2C File Offset: 0x005CAE2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1CF RID: 53711
		private float opl_p0;
	}
}
