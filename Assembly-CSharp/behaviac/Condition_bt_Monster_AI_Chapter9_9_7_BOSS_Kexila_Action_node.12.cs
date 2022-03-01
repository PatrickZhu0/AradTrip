using System;

namespace behaviac
{
	// Token: 0x0200320B RID: 12811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node38 : Condition
	{
		// Token: 0x06014CA0 RID: 85152 RVA: 0x0064326B File Offset: 0x0064166B
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node38()
		{
			this.opl_p0 = 21562;
		}

		// Token: 0x06014CA1 RID: 85153 RVA: 0x00643280 File Offset: 0x00641680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5ED RID: 58861
		private int opl_p0;
	}
}
