using System;

namespace behaviac
{
	// Token: 0x020022E2 RID: 8930
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node10 : Condition
	{
		// Token: 0x06012F3E RID: 77630 RVA: 0x00599C4B File Offset: 0x0059804B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node10()
		{
			this.opl_p0 = 0.03f;
		}

		// Token: 0x06012F3F RID: 77631 RVA: 0x00599C60 File Offset: 0x00598060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C951 RID: 51537
		private float opl_p0;
	}
}
