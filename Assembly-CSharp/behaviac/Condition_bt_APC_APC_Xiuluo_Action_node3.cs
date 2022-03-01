using System;

namespace behaviac
{
	// Token: 0x02001E33 RID: 7731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node3 : Condition
	{
		// Token: 0x06012614 RID: 75284 RVA: 0x0055EBB7 File Offset: 0x0055CFB7
		public Condition_bt_APC_APC_Xiuluo_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012615 RID: 75285 RVA: 0x0055EBCC File Offset: 0x0055CFCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFFC RID: 49148
		private float opl_p0;
	}
}
