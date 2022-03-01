using System;

namespace behaviac
{
	// Token: 0x02003889 RID: 14473
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node38 : Condition
	{
		// Token: 0x060158F6 RID: 88310 RVA: 0x00681A17 File Offset: 0x0067FE17
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node38()
		{
			this.opl_p0 = 21213;
		}

		// Token: 0x060158F7 RID: 88311 RVA: 0x00681A2C File Offset: 0x0067FE2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F28E RID: 62094
		private int opl_p0;
	}
}
