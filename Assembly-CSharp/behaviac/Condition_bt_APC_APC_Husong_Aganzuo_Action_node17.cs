using System;

namespace behaviac
{
	// Token: 0x02001D59 RID: 7513
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node17 : Condition
	{
		// Token: 0x06012471 RID: 74865 RVA: 0x00554FE1 File Offset: 0x005533E1
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012472 RID: 74866 RVA: 0x00554FF4 File Offset: 0x005533F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE62 RID: 48738
		private float opl_p0;
	}
}
