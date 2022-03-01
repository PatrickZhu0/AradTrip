using System;

namespace behaviac
{
	// Token: 0x020027C4 RID: 10180
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node67 : Condition
	{
		// Token: 0x060138C7 RID: 80071 RVA: 0x005D4791 File Offset: 0x005D2B91
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node67()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060138C8 RID: 80072 RVA: 0x005D47A4 File Offset: 0x005D2BA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D327 RID: 54055
		private float opl_p0;
	}
}
