using System;

namespace behaviac
{
	// Token: 0x02002F47 RID: 12103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node11 : Condition
	{
		// Token: 0x0601475E RID: 83806 RVA: 0x00627F73 File Offset: 0x00626373
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node11()
		{
			this.opl_p0 = 5005;
		}

		// Token: 0x0601475F RID: 83807 RVA: 0x00627F88 File Offset: 0x00626388
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0CE RID: 57550
		private int opl_p0;
	}
}
