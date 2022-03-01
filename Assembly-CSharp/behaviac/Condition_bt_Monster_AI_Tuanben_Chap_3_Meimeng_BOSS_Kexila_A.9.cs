using System;

namespace behaviac
{
	// Token: 0x020038DD RID: 14557
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node21 : Condition
	{
		// Token: 0x06015997 RID: 88471 RVA: 0x00685497 File Offset: 0x00683897
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node21()
		{
			this.opl_p0 = 21202;
		}

		// Token: 0x06015998 RID: 88472 RVA: 0x006854AC File Offset: 0x006838AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F349 RID: 62281
		private int opl_p0;
	}
}
