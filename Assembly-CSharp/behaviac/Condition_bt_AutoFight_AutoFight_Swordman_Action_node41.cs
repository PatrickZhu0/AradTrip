using System;

namespace behaviac
{
	// Token: 0x0200288F RID: 10383
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node41 : Condition
	{
		// Token: 0x06013A5B RID: 80475 RVA: 0x005DD59E File Offset: 0x005DB99E
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node41()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013A5C RID: 80476 RVA: 0x005DD5B4 File Offset: 0x005DB9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4B5 RID: 54453
		private float opl_p0;
	}
}
