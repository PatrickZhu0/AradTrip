using System;

namespace behaviac
{
	// Token: 0x020036C1 RID: 14017
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node8 : Condition
	{
		// Token: 0x0601559B RID: 87451 RVA: 0x00670CD7 File Offset: 0x0066F0D7
		public Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node8()
		{
			this.opl_p0 = 5330;
		}

		// Token: 0x0601559C RID: 87452 RVA: 0x00670CEC File Offset: 0x0066F0EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF6E RID: 61294
		private int opl_p0;
	}
}
