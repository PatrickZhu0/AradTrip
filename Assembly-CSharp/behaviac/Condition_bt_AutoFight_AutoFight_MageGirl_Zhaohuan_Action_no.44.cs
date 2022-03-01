using System;

namespace behaviac
{
	// Token: 0x02002783 RID: 10115
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node25 : Condition
	{
		// Token: 0x06013847 RID: 79943 RVA: 0x005D0C52 File Offset: 0x005CF052
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node25()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013848 RID: 79944 RVA: 0x005D0C68 File Offset: 0x005CF068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2A7 RID: 53927
		private float opl_p0;
	}
}
