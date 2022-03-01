using System;

namespace behaviac
{
	// Token: 0x020020A2 RID: 8354
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node2 : Condition
	{
		// Token: 0x06012ADB RID: 76507 RVA: 0x0057BE42 File Offset: 0x0057A242
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node2()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012ADC RID: 76508 RVA: 0x0057BE58 File Offset: 0x0057A258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4CE RID: 50382
		private float opl_p0;
	}
}
