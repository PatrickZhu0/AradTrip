using System;

namespace behaviac
{
	// Token: 0x02002888 RID: 10376
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node36 : Condition
	{
		// Token: 0x06013A4D RID: 80461 RVA: 0x005DD22A File Offset: 0x005DB62A
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node36()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013A4E RID: 80462 RVA: 0x005DD240 File Offset: 0x005DB640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4A6 RID: 54438
		private float opl_p0;
	}
}
