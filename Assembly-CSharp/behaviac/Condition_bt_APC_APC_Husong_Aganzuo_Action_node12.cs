using System;

namespace behaviac
{
	// Token: 0x02001D55 RID: 7509
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node12 : Condition
	{
		// Token: 0x06012469 RID: 74857 RVA: 0x00554E2D File Offset: 0x0055322D
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node12()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601246A RID: 74858 RVA: 0x00554E40 File Offset: 0x00553240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE5A RID: 48730
		private float opl_p0;
	}
}
