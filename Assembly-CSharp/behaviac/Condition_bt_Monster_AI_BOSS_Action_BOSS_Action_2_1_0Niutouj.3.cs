using System;

namespace behaviac
{
	// Token: 0x02002F43 RID: 12099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node6 : Condition
	{
		// Token: 0x06014756 RID: 83798 RVA: 0x00627DBF File Offset: 0x006261BF
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node6()
		{
			this.opl_p0 = 5004;
		}

		// Token: 0x06014757 RID: 83799 RVA: 0x00627DD4 File Offset: 0x006261D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0C6 RID: 57542
		private int opl_p0;
	}
}
