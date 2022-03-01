using System;

namespace behaviac
{
	// Token: 0x0200208A RID: 8330
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node2 : Condition
	{
		// Token: 0x06012AAC RID: 76460 RVA: 0x0057AB82 File Offset: 0x00578F82
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node2()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x06012AAD RID: 76461 RVA: 0x0057AB98 File Offset: 0x00578F98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C49F RID: 50335
		private float opl_p0;
	}
}
