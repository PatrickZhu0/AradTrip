using System;

namespace behaviac
{
	// Token: 0x020038AC RID: 14508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node32 : Condition
	{
		// Token: 0x06015937 RID: 88375 RVA: 0x00683986 File Offset: 0x00681D86
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node32()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015938 RID: 88376 RVA: 0x0068399C File Offset: 0x00681D9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2D3 RID: 62163
		private int opl_p0;
	}
}
