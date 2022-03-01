using System;

namespace behaviac
{
	// Token: 0x02001ED2 RID: 7890
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node4 : Condition
	{
		// Token: 0x06012749 RID: 75593 RVA: 0x005661C7 File Offset: 0x005645C7
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node4()
		{
			this.opl_p0 = 3009;
		}

		// Token: 0x0601274A RID: 75594 RVA: 0x005661DC File Offset: 0x005645DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C13B RID: 49467
		private int opl_p0;
	}
}
