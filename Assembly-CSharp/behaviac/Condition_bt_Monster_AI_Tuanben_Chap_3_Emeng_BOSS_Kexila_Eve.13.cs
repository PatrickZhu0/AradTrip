using System;

namespace behaviac
{
	// Token: 0x020038BE RID: 14526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node43 : Condition
	{
		// Token: 0x0601595B RID: 88411 RVA: 0x00683F3F File Offset: 0x0068233F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node43()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x0601595C RID: 88412 RVA: 0x00683F54 File Offset: 0x00682354
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F305 RID: 62213
		private int opl_p0;
	}
}
