using System;

namespace behaviac
{
	// Token: 0x02001DE4 RID: 7652
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node26 : Condition
	{
		// Token: 0x0601257E RID: 75134 RVA: 0x0055B3E1 File Offset: 0x005597E1
		public Condition_bt_APC_APC_Nianqishi_Action_node26()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601257F RID: 75135 RVA: 0x0055B3F4 File Offset: 0x005597F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF70 RID: 49008
		private float opl_p0;
	}
}
