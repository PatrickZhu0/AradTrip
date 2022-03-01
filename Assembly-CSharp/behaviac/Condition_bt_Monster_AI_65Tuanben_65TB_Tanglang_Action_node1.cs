using System;

namespace behaviac
{
	// Token: 0x02002C96 RID: 11414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node14 : Condition
	{
		// Token: 0x06014223 RID: 82467 RVA: 0x0060BDC9 File Offset: 0x0060A1C9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node14()
		{
			this.opl_p0 = 20753;
		}

		// Token: 0x06014224 RID: 82468 RVA: 0x0060BDDC File Offset: 0x0060A1DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBDF RID: 56287
		private int opl_p0;
	}
}
