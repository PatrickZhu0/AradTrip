using System;

namespace behaviac
{
	// Token: 0x02002F76 RID: 12150
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node68 : Condition
	{
		// Token: 0x060147BA RID: 83898 RVA: 0x0062A063 File Offset: 0x00628463
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node68()
		{
			this.opl_p0 = 5549;
		}

		// Token: 0x060147BB RID: 83899 RVA: 0x0062A078 File Offset: 0x00628478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E126 RID: 57638
		private int opl_p0;
	}
}
