using System;

namespace behaviac
{
	// Token: 0x02003D0F RID: 15631
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node3 : Action
	{
		// Token: 0x060161BB RID: 90555 RVA: 0x006AF063 File Offset: 0x006AD463
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 81290011;
			this.method_p1 = false;
		}

		// Token: 0x060161BC RID: 90556 RVA: 0x006AF084 File Offset: 0x006AD484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA4A RID: 64074
		private int method_p0;

		// Token: 0x0400FA4B RID: 64075
		private bool method_p1;
	}
}
