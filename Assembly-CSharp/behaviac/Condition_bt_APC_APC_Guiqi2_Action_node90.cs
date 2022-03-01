using System;

namespace behaviac
{
	// Token: 0x02001D1C RID: 7452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node90 : Condition
	{
		// Token: 0x060123FB RID: 74747 RVA: 0x00551EDE File Offset: 0x005502DE
		public Condition_bt_APC_APC_Guiqi2_Action_node90()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060123FC RID: 74748 RVA: 0x00551EF4 File Offset: 0x005502F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDEA RID: 48618
		private float opl_p0;
	}
}
