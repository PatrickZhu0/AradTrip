using System;

namespace behaviac
{
	// Token: 0x02003865 RID: 14437
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node62 : Action
	{
		// Token: 0x060158B0 RID: 88240 RVA: 0x0067FE7F File Offset: 0x0067E27F
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node62()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 0;
		}

		// Token: 0x060158B1 RID: 88241 RVA: 0x0067FEA0 File Offset: 0x0067E2A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F25C RID: 62044
		private int method_p0;

		// Token: 0x0400F25D RID: 62045
		private int method_p1;
	}
}
