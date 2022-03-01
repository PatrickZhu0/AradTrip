using System;

namespace behaviac
{
	// Token: 0x02001DDB RID: 7643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node48 : Condition
	{
		// Token: 0x0601256C RID: 75116 RVA: 0x0055B021 File Offset: 0x00559421
		public Condition_bt_APC_APC_Nianqishi_Action_node48()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601256D RID: 75117 RVA: 0x0055B034 File Offset: 0x00559434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF5D RID: 48989
		private float opl_p0;
	}
}
