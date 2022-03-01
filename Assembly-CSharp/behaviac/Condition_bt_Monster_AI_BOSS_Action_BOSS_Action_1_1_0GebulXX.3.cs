using System;

namespace behaviac
{
	// Token: 0x02002F36 RID: 12086
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node7 : Condition
	{
		// Token: 0x0601473D RID: 83773 RVA: 0x00627483 File Offset: 0x00625883
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node7()
		{
			this.opl_p0 = 5000;
		}

		// Token: 0x0601473E RID: 83774 RVA: 0x00627498 File Offset: 0x00625898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0AE RID: 57518
		private int opl_p0;
	}
}
