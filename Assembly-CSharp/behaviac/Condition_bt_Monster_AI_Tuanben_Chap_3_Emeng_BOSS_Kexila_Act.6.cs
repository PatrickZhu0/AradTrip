using System;

namespace behaviac
{
	// Token: 0x02003840 RID: 14400
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node52 : Condition
	{
		// Token: 0x06015866 RID: 88166 RVA: 0x0067EFAF File Offset: 0x0067D3AF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node52()
		{
			this.opl_p0 = 21217;
		}

		// Token: 0x06015867 RID: 88167 RVA: 0x0067EFC4 File Offset: 0x0067D3C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F229 RID: 61993
		private int opl_p0;
	}
}
