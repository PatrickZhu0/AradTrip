using System;

namespace behaviac
{
	// Token: 0x020020B2 RID: 8370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node22 : Condition
	{
		// Token: 0x06012AFB RID: 76539 RVA: 0x0057C6C2 File Offset: 0x0057AAC2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012AFC RID: 76540 RVA: 0x0057C6D8 File Offset: 0x0057AAD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4EE RID: 50414
		private float opl_p0;
	}
}
