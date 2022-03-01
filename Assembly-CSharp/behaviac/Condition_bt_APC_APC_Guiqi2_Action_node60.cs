using System;

namespace behaviac
{
	// Token: 0x02001D20 RID: 7456
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node60 : Condition
	{
		// Token: 0x06012403 RID: 74755 RVA: 0x00552092 File Offset: 0x00550492
		public Condition_bt_APC_APC_Guiqi2_Action_node60()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012404 RID: 74756 RVA: 0x005520A8 File Offset: 0x005504A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDF2 RID: 48626
		private float opl_p0;
	}
}
