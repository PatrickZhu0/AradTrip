using System;

namespace behaviac
{
	// Token: 0x02002CAE RID: 11438
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node25 : Action
	{
		// Token: 0x06014251 RID: 82513 RVA: 0x0060CDE5 File Offset: 0x0060B1E5
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521951;
		}

		// Token: 0x06014252 RID: 82514 RVA: 0x0060CE06 File Offset: 0x0060B206
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC09 RID: 56329
		private BE_Target method_p0;

		// Token: 0x0400DC0A RID: 56330
		private int method_p1;
	}
}
