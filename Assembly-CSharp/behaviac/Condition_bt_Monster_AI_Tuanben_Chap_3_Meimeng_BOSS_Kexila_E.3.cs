using System;

namespace behaviac
{
	// Token: 0x0200394B RID: 14667
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7 : Condition
	{
		// Token: 0x06015A70 RID: 88688 RVA: 0x0068A72B File Offset: 0x00688B2B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7()
		{
			this.opl_p0 = 21206;
		}

		// Token: 0x06015A71 RID: 88689 RVA: 0x0068A740 File Offset: 0x00688B40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3FF RID: 62463
		private int opl_p0;
	}
}
