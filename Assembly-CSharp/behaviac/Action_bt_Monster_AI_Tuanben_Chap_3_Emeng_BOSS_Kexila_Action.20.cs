using System;

namespace behaviac
{
	// Token: 0x02003877 RID: 14455
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node64 : Action
	{
		// Token: 0x060158D2 RID: 88274 RVA: 0x0068135A File Offset: 0x0067F75A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node64()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3000;
			this.method_p1 = 1;
		}

		// Token: 0x060158D3 RID: 88275 RVA: 0x0068137C File Offset: 0x0067F77C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F274 RID: 62068
		private int method_p0;

		// Token: 0x0400F275 RID: 62069
		private int method_p1;
	}
}
