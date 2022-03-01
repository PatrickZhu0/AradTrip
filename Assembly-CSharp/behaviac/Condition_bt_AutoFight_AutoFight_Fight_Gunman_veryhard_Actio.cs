using System;

namespace behaviac
{
	// Token: 0x020021E2 RID: 8674
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node2 : Condition
	{
		// Token: 0x06012D51 RID: 77137 RVA: 0x0058B28E File Offset: 0x0058968E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node2()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012D52 RID: 77138 RVA: 0x0058B2A4 File Offset: 0x005896A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C744 RID: 51012
		private float opl_p0;
	}
}
