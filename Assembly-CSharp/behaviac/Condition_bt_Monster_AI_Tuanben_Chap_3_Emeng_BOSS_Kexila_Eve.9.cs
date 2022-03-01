using System;

namespace behaviac
{
	// Token: 0x020038B2 RID: 14514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node36 : Condition
	{
		// Token: 0x06015943 RID: 88387 RVA: 0x00683B9A File Offset: 0x00681F9A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node36()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015944 RID: 88388 RVA: 0x00683BB0 File Offset: 0x00681FB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2E5 RID: 62181
		private int opl_p0;
	}
}
