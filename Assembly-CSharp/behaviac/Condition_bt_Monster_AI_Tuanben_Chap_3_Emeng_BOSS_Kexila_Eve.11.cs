using System;

namespace behaviac
{
	// Token: 0x020038B9 RID: 14521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node40 : Condition
	{
		// Token: 0x06015951 RID: 88401 RVA: 0x00683DCF File Offset: 0x006821CF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node40()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015952 RID: 88402 RVA: 0x00683DE4 File Offset: 0x006821E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2FA RID: 62202
		private int opl_p0;
	}
}
