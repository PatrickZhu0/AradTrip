using System;

namespace behaviac
{
	// Token: 0x020038DA RID: 14554
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node17 : Condition
	{
		// Token: 0x06015991 RID: 88465 RVA: 0x0068535B File Offset: 0x0068375B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node17()
		{
			this.opl_p0 = 21201;
		}

		// Token: 0x06015992 RID: 88466 RVA: 0x00685370 File Offset: 0x00683770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F345 RID: 62277
		private int opl_p0;
	}
}
