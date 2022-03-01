using System;

namespace behaviac
{
	// Token: 0x02001FAB RID: 8107
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node7 : Condition
	{
		// Token: 0x060128F4 RID: 76020 RVA: 0x00570176 File Offset: 0x0056E576
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node7()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060128F5 RID: 76021 RVA: 0x0057018C File Offset: 0x0056E58C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2E6 RID: 49894
		private float opl_p0;
	}
}
