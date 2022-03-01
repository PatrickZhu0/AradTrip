using System;

namespace behaviac
{
	// Token: 0x02001D02 RID: 7426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node11 : Condition
	{
		// Token: 0x060123C9 RID: 74697 RVA: 0x00550C8D File Offset: 0x0054F08D
		public Condition_bt_APC_APC_Demian_Action_node11()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060123CA RID: 74698 RVA: 0x00550CA0 File Offset: 0x0054F0A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDC1 RID: 48577
		private float opl_p0;
	}
}
