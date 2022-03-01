using System;

namespace behaviac
{
	// Token: 0x02003869 RID: 14441
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node49 : Condition
	{
		// Token: 0x060158B6 RID: 88246 RVA: 0x00680DD7 File Offset: 0x0067F1D7
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node49()
		{
			this.opl_p0 = 21216;
		}

		// Token: 0x060158B7 RID: 88247 RVA: 0x00680DEC File Offset: 0x0067F1EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F261 RID: 62049
		private int opl_p0;
	}
}
