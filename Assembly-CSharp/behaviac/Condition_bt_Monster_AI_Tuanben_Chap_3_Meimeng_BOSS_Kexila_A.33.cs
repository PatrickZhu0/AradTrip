using System;

namespace behaviac
{
	// Token: 0x02003903 RID: 14595
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node69 : Condition
	{
		// Token: 0x060159E1 RID: 88545 RVA: 0x00687227 File Offset: 0x00685627
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node69()
		{
			this.opl_p0 = 21209;
		}

		// Token: 0x060159E2 RID: 88546 RVA: 0x0068723C File Offset: 0x0068563C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F380 RID: 62336
		private int opl_p0;
	}
}
