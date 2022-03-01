using System;

namespace behaviac
{
	// Token: 0x02003D01 RID: 15617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node0 : Condition
	{
		// Token: 0x060161A0 RID: 90528 RVA: 0x006AE8FA File Offset: 0x006ACCFA
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node0()
		{
			this.opl_p0 = 81290011;
			this.opl_p1 = 2;
		}

		// Token: 0x060161A1 RID: 90529 RVA: 0x006AE914 File Offset: 0x006ACD14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA39 RID: 64057
		private int opl_p0;

		// Token: 0x0400FA3A RID: 64058
		private int opl_p1;
	}
}
