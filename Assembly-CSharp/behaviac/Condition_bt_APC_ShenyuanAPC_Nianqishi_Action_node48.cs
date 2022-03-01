using System;

namespace behaviac
{
	// Token: 0x02001EAE RID: 7854
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node48 : Condition
	{
		// Token: 0x06012704 RID: 75524 RVA: 0x00564A69 File Offset: 0x00562E69
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node48()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012705 RID: 75525 RVA: 0x00564A7C File Offset: 0x00562E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0F2 RID: 49394
		private float opl_p0;
	}
}
