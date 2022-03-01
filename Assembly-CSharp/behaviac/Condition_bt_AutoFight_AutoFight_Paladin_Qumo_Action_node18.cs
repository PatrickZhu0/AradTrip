using System;

namespace behaviac
{
	// Token: 0x020027C0 RID: 10176
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node18 : Condition
	{
		// Token: 0x060138BF RID: 80063 RVA: 0x005D45DD File Offset: 0x005D29DD
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node18()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060138C0 RID: 80064 RVA: 0x005D45F0 File Offset: 0x005D29F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D31F RID: 54047
		private float opl_p0;
	}
}
