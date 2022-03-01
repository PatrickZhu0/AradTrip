using System;

namespace behaviac
{
	// Token: 0x020038F7 RID: 14583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node54 : Condition
	{
		// Token: 0x060159CB RID: 88523 RVA: 0x00685F3B File Offset: 0x0068433B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node54()
		{
			this.opl_p0 = 21203;
		}

		// Token: 0x060159CC RID: 88524 RVA: 0x00685F50 File Offset: 0x00684350
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F371 RID: 62321
		private int opl_p0;
	}
}
