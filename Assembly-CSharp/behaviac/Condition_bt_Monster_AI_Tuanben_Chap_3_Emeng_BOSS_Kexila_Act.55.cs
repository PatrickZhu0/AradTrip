using System;

namespace behaviac
{
	// Token: 0x0200388D RID: 14477
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node42 : Condition
	{
		// Token: 0x060158FE RID: 88318 RVA: 0x00681B9B File Offset: 0x0067FF9B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node42()
		{
			this.opl_p0 = 21219;
		}

		// Token: 0x060158FF RID: 88319 RVA: 0x00681BB0 File Offset: 0x0067FFB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F294 RID: 62100
		private int opl_p0;
	}
}
