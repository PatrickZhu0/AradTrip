using System;

namespace behaviac
{
	// Token: 0x0200288C RID: 10380
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node84 : Condition
	{
		// Token: 0x06013A55 RID: 80469 RVA: 0x005DD3DA File Offset: 0x005DB7DA
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node84()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013A56 RID: 80470 RVA: 0x005DD3F0 File Offset: 0x005DB7F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4AE RID: 54446
		private float opl_p0;
	}
}
