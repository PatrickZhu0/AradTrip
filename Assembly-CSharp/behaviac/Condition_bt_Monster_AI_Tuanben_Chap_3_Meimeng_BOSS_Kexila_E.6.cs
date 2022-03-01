using System;

namespace behaviac
{
	// Token: 0x0200395A RID: 14682
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node58 : Condition
	{
		// Token: 0x06015A8B RID: 88715 RVA: 0x0068AEAA File Offset: 0x006892AA
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node58()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015A8C RID: 88716 RVA: 0x0068AEC0 File Offset: 0x006892C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F422 RID: 62498
		private int opl_p0;
	}
}
