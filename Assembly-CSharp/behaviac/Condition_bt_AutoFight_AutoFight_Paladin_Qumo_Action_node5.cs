using System;

namespace behaviac
{
	// Token: 0x020027B4 RID: 10164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node5 : Condition
	{
		// Token: 0x060138A7 RID: 80039 RVA: 0x005D40BF File Offset: 0x005D24BF
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node5()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060138A8 RID: 80040 RVA: 0x005D40D4 File Offset: 0x005D24D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D307 RID: 54023
		private float opl_p0;
	}
}
