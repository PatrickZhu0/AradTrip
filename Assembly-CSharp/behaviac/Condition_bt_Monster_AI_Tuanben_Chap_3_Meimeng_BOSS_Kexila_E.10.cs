using System;

namespace behaviac
{
	// Token: 0x02003966 RID: 14694
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node40 : Condition
	{
		// Token: 0x06015AA3 RID: 88739 RVA: 0x0068B2A3 File Offset: 0x006896A3
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node40()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015AA4 RID: 88740 RVA: 0x0068B2B8 File Offset: 0x006896B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F448 RID: 62536
		private int opl_p0;
	}
}
