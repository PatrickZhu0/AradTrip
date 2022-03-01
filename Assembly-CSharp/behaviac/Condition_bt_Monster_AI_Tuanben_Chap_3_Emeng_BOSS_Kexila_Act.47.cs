using System;

namespace behaviac
{
	// Token: 0x02003881 RID: 14465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node51 : Condition
	{
		// Token: 0x060158E6 RID: 88294 RVA: 0x0068170B File Offset: 0x0067FB0B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node51()
		{
			this.opl_p0 = 21216;
		}

		// Token: 0x060158E7 RID: 88295 RVA: 0x00681720 File Offset: 0x0067FB20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F284 RID: 62084
		private int opl_p0;
	}
}
