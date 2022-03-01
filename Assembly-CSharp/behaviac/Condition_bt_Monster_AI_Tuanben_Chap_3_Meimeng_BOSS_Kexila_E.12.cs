using System;

namespace behaviac
{
	// Token: 0x0200396B RID: 14699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node43 : Condition
	{
		// Token: 0x06015AAD RID: 88749 RVA: 0x0068B413 File Offset: 0x00689813
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node43()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015AAE RID: 88750 RVA: 0x0068B428 File Offset: 0x00689828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F453 RID: 62547
		private int opl_p0;
	}
}
