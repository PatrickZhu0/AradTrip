using System;

namespace behaviac
{
	// Token: 0x02003959 RID: 14681
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node49 : Condition
	{
		// Token: 0x06015A89 RID: 88713 RVA: 0x0068AE5A File Offset: 0x0068925A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node49()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015A8A RID: 88714 RVA: 0x0068AE70 File Offset: 0x00689270
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F421 RID: 62497
		private int opl_p0;
	}
}
