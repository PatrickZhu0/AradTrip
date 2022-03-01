using System;

namespace behaviac
{
	// Token: 0x02001DC8 RID: 7624
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node89 : Condition
	{
		// Token: 0x06012548 RID: 75080 RVA: 0x0055A17D File Offset: 0x0055857D
		public Condition_bt_APC_APC_Mishushi_Action_node89()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012549 RID: 75081 RVA: 0x0055A190 File Offset: 0x00558590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF3E RID: 48958
		private float opl_p0;
	}
}
