using System;

namespace behaviac
{
	// Token: 0x02001D08 RID: 7432
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node19 : Condition
	{
		// Token: 0x060123D5 RID: 74709 RVA: 0x00550EE3 File Offset: 0x0054F2E3
		public Condition_bt_APC_APC_Demian_Action_node19()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060123D6 RID: 74710 RVA: 0x00550EF8 File Offset: 0x0054F2F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDCD RID: 48589
		private float opl_p0;
	}
}
