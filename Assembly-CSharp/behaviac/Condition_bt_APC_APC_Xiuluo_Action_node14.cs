using System;

namespace behaviac
{
	// Token: 0x02001E37 RID: 7735
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node14 : Condition
	{
		// Token: 0x0601261C RID: 75292 RVA: 0x0055EF99 File Offset: 0x0055D399
		public Condition_bt_APC_APC_Xiuluo_Action_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601261D RID: 75293 RVA: 0x0055EFAC File Offset: 0x0055D3AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C004 RID: 49156
		private float opl_p0;
	}
}
