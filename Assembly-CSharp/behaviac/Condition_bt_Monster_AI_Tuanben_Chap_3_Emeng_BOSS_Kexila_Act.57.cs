using System;

namespace behaviac
{
	// Token: 0x02003891 RID: 14481
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node46 : Condition
	{
		// Token: 0x06015906 RID: 88326 RVA: 0x00681D1F File Offset: 0x0068011F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node46()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x06015907 RID: 88327 RVA: 0x00681D34 File Offset: 0x00680134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F29A RID: 62106
		private int opl_p0;
	}
}
