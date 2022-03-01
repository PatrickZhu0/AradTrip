using System;

namespace behaviac
{
	// Token: 0x02003738 RID: 14136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node5 : Condition
	{
		// Token: 0x0601567B RID: 87675 RVA: 0x0067546F File Offset: 0x0067386F
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node5()
		{
			this.opl_p0 = 5284;
		}

		// Token: 0x0601567C RID: 87676 RVA: 0x00675484 File Offset: 0x00673884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F04B RID: 61515
		private int opl_p0;
	}
}
