using System;

namespace behaviac
{
	// Token: 0x020036C6 RID: 14022
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3 : Condition
	{
		// Token: 0x060155A4 RID: 87460 RVA: 0x006710F7 File Offset: 0x0066F4F7
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node3()
		{
			this.opl_p0 = 5434;
		}

		// Token: 0x060155A5 RID: 87461 RVA: 0x0067110C File Offset: 0x0066F50C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF77 RID: 61303
		private int opl_p0;
	}
}
