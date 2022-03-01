using System;

namespace behaviac
{
	// Token: 0x02001DE0 RID: 7648
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node6 : Condition
	{
		// Token: 0x06012576 RID: 75126 RVA: 0x0055B231 File Offset: 0x00559631
		public Condition_bt_APC_APC_Nianqishi_Action_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012577 RID: 75127 RVA: 0x0055B244 File Offset: 0x00559644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF68 RID: 49000
		private float opl_p0;
	}
}
