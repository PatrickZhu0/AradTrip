using System;

namespace behaviac
{
	// Token: 0x02003897 RID: 14487
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node62 : Action
	{
		// Token: 0x06015912 RID: 88338 RVA: 0x00681F97 File Offset: 0x00680397
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node62()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 5;
		}

		// Token: 0x06015913 RID: 88339 RVA: 0x00681FB8 File Offset: 0x006803B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F2A2 RID: 62114
		private int method_p0;

		// Token: 0x0400F2A3 RID: 62115
		private int method_p1;
	}
}
