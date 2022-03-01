using System;

namespace behaviac
{
	// Token: 0x0200208E RID: 8334
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node7 : Condition
	{
		// Token: 0x06012AB4 RID: 76468 RVA: 0x0057ADCE File Offset: 0x005791CE
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node7()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012AB5 RID: 76469 RVA: 0x0057ADE4 File Offset: 0x005791E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4A7 RID: 50343
		private float opl_p0;
	}
}
