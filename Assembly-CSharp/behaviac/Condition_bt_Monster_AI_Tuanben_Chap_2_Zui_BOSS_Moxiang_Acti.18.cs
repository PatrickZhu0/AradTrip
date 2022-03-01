using System;

namespace behaviac
{
	// Token: 0x02003762 RID: 14178
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node38 : Condition
	{
		// Token: 0x060156CB RID: 87755 RVA: 0x00676963 File Offset: 0x00674D63
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node38()
		{
			this.opl_p0 = 21191;
		}

		// Token: 0x060156CC RID: 87756 RVA: 0x00676978 File Offset: 0x00674D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F099 RID: 61593
		private int opl_p0;
	}
}
