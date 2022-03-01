using System;

namespace behaviac
{
	// Token: 0x02003E14 RID: 15892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node18 : Condition
	{
		// Token: 0x060163B1 RID: 91057 RVA: 0x006B86A3 File Offset: 0x006B6AA3
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node18()
		{
			this.opl_p0 = 7237;
		}

		// Token: 0x060163B2 RID: 91058 RVA: 0x006B86B8 File Offset: 0x006B6AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC1A RID: 64538
		private int opl_p0;
	}
}
