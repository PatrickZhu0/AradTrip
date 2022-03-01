using System;

namespace behaviac
{
	// Token: 0x0200395F RID: 14687
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node36 : Condition
	{
		// Token: 0x06015A95 RID: 88725 RVA: 0x0068B06E File Offset: 0x0068946E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node36()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015A96 RID: 88726 RVA: 0x0068B084 File Offset: 0x00689484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F433 RID: 62515
		private int opl_p0;
	}
}
