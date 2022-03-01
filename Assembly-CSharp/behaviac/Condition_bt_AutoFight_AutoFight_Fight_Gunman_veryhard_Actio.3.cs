using System;

namespace behaviac
{
	// Token: 0x020021E6 RID: 8678
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node7 : Condition
	{
		// Token: 0x06012D59 RID: 77145 RVA: 0x0058B4DA File Offset: 0x005898DA
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node7()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012D5A RID: 77146 RVA: 0x0058B4F0 File Offset: 0x005898F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C74C RID: 51020
		private float opl_p0;
	}
}
