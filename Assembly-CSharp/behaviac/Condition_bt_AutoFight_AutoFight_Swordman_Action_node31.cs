using System;

namespace behaviac
{
	// Token: 0x02002884 RID: 10372
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node31 : Condition
	{
		// Token: 0x06013A45 RID: 80453 RVA: 0x005DD01A File Offset: 0x005DB41A
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node31()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013A46 RID: 80454 RVA: 0x005DD030 File Offset: 0x005DB430
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D49E RID: 54430
		private float opl_p0;
	}
}
