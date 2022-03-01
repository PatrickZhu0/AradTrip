using System;

namespace behaviac
{
	// Token: 0x02003E07 RID: 15879
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node29 : Condition
	{
		// Token: 0x06016397 RID: 91031 RVA: 0x006B810B File Offset: 0x006B650B
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node29()
		{
			this.opl_p0 = 5198;
		}

		// Token: 0x06016398 RID: 91032 RVA: 0x006B8120 File Offset: 0x006B6520
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBFE RID: 64510
		private int opl_p0;
	}
}
