using System;

namespace behaviac
{
	// Token: 0x02003927 RID: 14631
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node25 : Condition
	{
		// Token: 0x06015A29 RID: 88617 RVA: 0x00688147 File Offset: 0x00686547
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node25()
		{
			this.opl_p0 = 21459;
		}

		// Token: 0x06015A2A RID: 88618 RVA: 0x0068815C File Offset: 0x0068655C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3BA RID: 62394
		private int opl_p0;
	}
}
