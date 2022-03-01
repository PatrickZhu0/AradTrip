using System;

namespace behaviac
{
	// Token: 0x020038AD RID: 14509
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node58 : Condition
	{
		// Token: 0x06015939 RID: 88377 RVA: 0x006839D6 File Offset: 0x00681DD6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node58()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x0601593A RID: 88378 RVA: 0x006839EC File Offset: 0x00681DEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2D4 RID: 62164
		private int opl_p0;
	}
}
