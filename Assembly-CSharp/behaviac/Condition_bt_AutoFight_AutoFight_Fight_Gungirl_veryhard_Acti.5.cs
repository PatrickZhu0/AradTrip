using System;

namespace behaviac
{
	// Token: 0x020020AA RID: 8362
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node12 : Condition
	{
		// Token: 0x06012AEB RID: 76523 RVA: 0x0057C22A File Offset: 0x0057A62A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node12()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012AEC RID: 76524 RVA: 0x0057C240 File Offset: 0x0057A640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4DE RID: 50398
		private float opl_p0;
	}
}
