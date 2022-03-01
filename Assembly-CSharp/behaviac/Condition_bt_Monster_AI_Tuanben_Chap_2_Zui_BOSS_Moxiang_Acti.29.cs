using System;

namespace behaviac
{
	// Token: 0x02003772 RID: 14194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node85 : Condition
	{
		// Token: 0x060156EB RID: 87787 RVA: 0x00676FEF File Offset: 0x006753EF
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node85()
		{
			this.opl_p0 = 21195;
		}

		// Token: 0x060156EC RID: 87788 RVA: 0x00677004 File Offset: 0x00675404
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0B0 RID: 61616
		private int opl_p0;
	}
}
