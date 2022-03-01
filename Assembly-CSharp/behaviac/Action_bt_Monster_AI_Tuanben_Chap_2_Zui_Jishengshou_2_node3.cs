using System;

namespace behaviac
{
	// Token: 0x020037C3 RID: 14275
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3 : Action
	{
		// Token: 0x06015786 RID: 87942 RVA: 0x0067AF9A File Offset: 0x0067939A
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521794;
			this.method_p2 = 2500;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015787 RID: 87943 RVA: 0x0067AFD5 File Offset: 0x006793D5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F139 RID: 61753
		private BE_Target method_p0;

		// Token: 0x0400F13A RID: 61754
		private int method_p1;

		// Token: 0x0400F13B RID: 61755
		private int method_p2;

		// Token: 0x0400F13C RID: 61756
		private int method_p3;

		// Token: 0x0400F13D RID: 61757
		private int method_p4;
	}
}
