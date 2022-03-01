using System;

namespace behaviac
{
	// Token: 0x020020A6 RID: 8358
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node7 : Condition
	{
		// Token: 0x06012AE3 RID: 76515 RVA: 0x0057C08E File Offset: 0x0057A48E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node7()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012AE4 RID: 76516 RVA: 0x0057C0A4 File Offset: 0x0057A4A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4D6 RID: 50390
		private float opl_p0;
	}
}
