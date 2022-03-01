using System;

namespace behaviac
{
	// Token: 0x0200209E RID: 8350
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node27 : Condition
	{
		// Token: 0x06012AD4 RID: 76500 RVA: 0x0057B59E File Offset: 0x0057999E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node27()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012AD5 RID: 76501 RVA: 0x0057B5B4 File Offset: 0x005799B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4C7 RID: 50375
		private float opl_p0;
	}
}
