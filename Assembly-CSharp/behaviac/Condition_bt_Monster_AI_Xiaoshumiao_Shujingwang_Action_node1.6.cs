using System;

namespace behaviac
{
	// Token: 0x02003E18 RID: 15896
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node14 : Condition
	{
		// Token: 0x060163B9 RID: 91065 RVA: 0x006B883F File Offset: 0x006B6C3F
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node14()
		{
			this.opl_p0 = 7241;
		}

		// Token: 0x060163BA RID: 91066 RVA: 0x006B8854 File Offset: 0x006B6C54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC21 RID: 64545
		private int opl_p0;
	}
}
