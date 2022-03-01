using System;

namespace behaviac
{
	// Token: 0x0200245A RID: 9306
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node13 : Condition
	{
		// Token: 0x06013206 RID: 78342 RVA: 0x005ACE9B File Offset: 0x005AB29B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013207 RID: 78343 RVA: 0x005ACEB0 File Offset: 0x005AB2B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC2C RID: 52268
		private int opl_p0;
	}
}
