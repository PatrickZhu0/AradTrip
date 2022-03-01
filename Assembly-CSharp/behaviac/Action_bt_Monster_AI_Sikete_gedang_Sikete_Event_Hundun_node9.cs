using System;

namespace behaviac
{
	// Token: 0x0200373B RID: 14139
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node9 : Action
	{
		// Token: 0x06015681 RID: 87681 RVA: 0x006755BF File Offset: 0x006739BF
		public Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015682 RID: 87682 RVA: 0x006755E0 File Offset: 0x006739E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F051 RID: 61521
		private BE_Target method_p0;

		// Token: 0x0400F052 RID: 61522
		private int method_p1;
	}
}
