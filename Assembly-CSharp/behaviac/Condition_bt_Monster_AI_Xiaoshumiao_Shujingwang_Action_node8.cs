using System;

namespace behaviac
{
	// Token: 0x02003E0B RID: 15883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node8 : Condition
	{
		// Token: 0x0601639F RID: 91039 RVA: 0x006B82BF File Offset: 0x006B66BF
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node8()
		{
			this.opl_p0 = 7240;
		}

		// Token: 0x060163A0 RID: 91040 RVA: 0x006B82D4 File Offset: 0x006B66D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC06 RID: 64518
		private int opl_p0;
	}
}
