using System;

namespace behaviac
{
	// Token: 0x02003986 RID: 14726
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node27 : Condition
	{
		// Token: 0x06015AE3 RID: 88803 RVA: 0x0068BC2D File Offset: 0x0068A02D
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node27()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015AE4 RID: 88804 RVA: 0x0068BC3C File Offset: 0x0068A03C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 9000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F483 RID: 62595
		private int opl_p0;
	}
}
