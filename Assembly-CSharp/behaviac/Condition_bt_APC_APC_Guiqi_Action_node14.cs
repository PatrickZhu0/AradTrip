using System;

namespace behaviac
{
	// Token: 0x02001D32 RID: 7474
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node14 : Condition
	{
		// Token: 0x06012426 RID: 74790 RVA: 0x0055335D File Offset: 0x0055175D
		public Condition_bt_APC_APC_Guiqi_Action_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012427 RID: 74791 RVA: 0x00553370 File Offset: 0x00551770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE18 RID: 48664
		private float opl_p0;
	}
}
