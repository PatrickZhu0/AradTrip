using System;

namespace behaviac
{
	// Token: 0x02003950 RID: 14672
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6 : Action
	{
		// Token: 0x06015A7A RID: 88698 RVA: 0x0068A92D File Offset: 0x00688D2D
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 1;
		}

		// Token: 0x06015A7B RID: 88699 RVA: 0x0068A950 File Offset: 0x00688D50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F40E RID: 62478
		private int method_p0;

		// Token: 0x0400F40F RID: 62479
		private int method_p1;
	}
}
