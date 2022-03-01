using System;

namespace behaviac
{
	// Token: 0x02002274 RID: 8820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node24 : Condition
	{
		// Token: 0x06012E6C RID: 77420 RVA: 0x00592F6E File Offset: 0x0059136E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node24()
		{
			this.opl_p0 = 0.38f;
		}

		// Token: 0x06012E6D RID: 77421 RVA: 0x00592F84 File Offset: 0x00591384
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C877 RID: 51319
		private float opl_p0;
	}
}
