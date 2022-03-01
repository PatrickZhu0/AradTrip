using System;

namespace behaviac
{
	// Token: 0x020027D0 RID: 10192
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node33 : Condition
	{
		// Token: 0x060138DF RID: 80095 RVA: 0x005D4CAD File Offset: 0x005D30AD
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node33()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060138E0 RID: 80096 RVA: 0x005D4CC0 File Offset: 0x005D30C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D33F RID: 54079
		private float opl_p0;
	}
}
