using System;

namespace behaviac
{
	// Token: 0x0200209A RID: 8346
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node22 : Condition
	{
		// Token: 0x06012ACC RID: 76492 RVA: 0x0057B402 File Offset: 0x00579802
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012ACD RID: 76493 RVA: 0x0057B418 File Offset: 0x00579818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4BF RID: 50367
		private float opl_p0;
	}
}
