using System;

namespace behaviac
{
	// Token: 0x02003595 RID: 13717
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node6 : Condition
	{
		// Token: 0x0601535A RID: 86874 RVA: 0x0066484D File Offset: 0x00662C4D
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node6()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x0601535B RID: 86875 RVA: 0x0066486C File Offset: 0x00662C6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED21 RID: 60705
		private BE_Target opl_p0;

		// Token: 0x0400ED22 RID: 60706
		private BE_Equal opl_p1;

		// Token: 0x0400ED23 RID: 60707
		private BE_State opl_p2;
	}
}
