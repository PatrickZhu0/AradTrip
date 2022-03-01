using System;

namespace behaviac
{
	// Token: 0x02003D25 RID: 15653
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node0 : Condition
	{
		// Token: 0x060161E4 RID: 90596 RVA: 0x006AFD10 File Offset: 0x006AE110
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node0()
		{
			this.opl_p0 = 81280011;
			this.opl_p1 = 2;
		}

		// Token: 0x060161E5 RID: 90597 RVA: 0x006AFD2C File Offset: 0x006AE12C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA63 RID: 64099
		private int opl_p0;

		// Token: 0x0400FA64 RID: 64100
		private int opl_p1;
	}
}
