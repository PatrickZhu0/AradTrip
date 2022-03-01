using System;

namespace behaviac
{
	// Token: 0x020027EC RID: 10220
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node77 : Condition
	{
		// Token: 0x06013917 RID: 80151 RVA: 0x005D5899 File Offset: 0x005D3C99
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node77()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013918 RID: 80152 RVA: 0x005D58AC File Offset: 0x005D3CAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D377 RID: 54135
		private float opl_p0;
	}
}
