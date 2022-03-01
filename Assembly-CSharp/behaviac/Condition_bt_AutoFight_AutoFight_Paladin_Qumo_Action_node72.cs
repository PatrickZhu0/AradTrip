using System;

namespace behaviac
{
	// Token: 0x020027F0 RID: 10224
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node72 : Condition
	{
		// Token: 0x0601391F RID: 80159 RVA: 0x005D5A4D File Offset: 0x005D3E4D
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node72()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06013920 RID: 80160 RVA: 0x005D5A60 File Offset: 0x005D3E60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D37F RID: 54143
		private float opl_p0;
	}
}
