using System;

namespace behaviac
{
	// Token: 0x02003873 RID: 14451
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node63 : Action
	{
		// Token: 0x060158CA RID: 88266 RVA: 0x006811D6 File Offset: 0x0067F5D6
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node63()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3000;
			this.method_p1 = 0;
		}

		// Token: 0x060158CB RID: 88267 RVA: 0x006811F8 File Offset: 0x0067F5F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F26E RID: 62062
		private int method_p0;

		// Token: 0x0400F26F RID: 62063
		private int method_p1;
	}
}
