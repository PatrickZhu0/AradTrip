using System;

namespace behaviac
{
	// Token: 0x02001D52 RID: 7506
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node8 : Condition
	{
		// Token: 0x06012463 RID: 74851 RVA: 0x00554C09 File Offset: 0x00553009
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012464 RID: 74852 RVA: 0x00554C1C File Offset: 0x0055301C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE53 RID: 48723
		private float opl_p0;
	}
}
