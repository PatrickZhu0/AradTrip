using System;

namespace behaviac
{
	// Token: 0x0200287C RID: 10364
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node5 : Condition
	{
		// Token: 0x06013A35 RID: 80437 RVA: 0x005DCCB6 File Offset: 0x005DB0B6
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node5()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013A36 RID: 80438 RVA: 0x005DCCCC File Offset: 0x005DB0CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D48E RID: 54414
		private float opl_p0;
	}
}
