using System;

namespace behaviac
{
	// Token: 0x02003862 RID: 14434
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node58 : Condition
	{
		// Token: 0x060158AA RID: 88234 RVA: 0x0067FD43 File Offset: 0x0067E143
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node58()
		{
			this.opl_p0 = 21214;
		}

		// Token: 0x060158AB RID: 88235 RVA: 0x0067FD58 File Offset: 0x0067E158
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F258 RID: 62040
		private int opl_p0;
	}
}
