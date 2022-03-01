using System;

namespace behaviac
{
	// Token: 0x020021FC RID: 8700
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_hard_Move_node5 : Condition
	{
		// Token: 0x06012D84 RID: 77188 RVA: 0x0058C619 File Offset: 0x0058AA19
		public Condition_bt_AutoFight_AutoFight_Fight_hard_Move_node5()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012D85 RID: 77189 RVA: 0x0058C62C File Offset: 0x0058AA2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C775 RID: 51061
		private float opl_p0;
	}
}
