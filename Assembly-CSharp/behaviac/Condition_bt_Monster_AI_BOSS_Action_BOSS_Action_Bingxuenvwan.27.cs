using System;

namespace behaviac
{
	// Token: 0x02002F8F RID: 12175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node69 : Condition
	{
		// Token: 0x060147EC RID: 83948 RVA: 0x0062AA37 File Offset: 0x00628E37
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node69()
		{
			this.opl_p0 = 5531;
		}

		// Token: 0x060147ED RID: 83949 RVA: 0x0062AA4C File Offset: 0x00628E4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E152 RID: 57682
		private int opl_p0;
	}
}
