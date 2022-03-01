using System;

namespace behaviac
{
	// Token: 0x02002645 RID: 9797
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node98 : Condition
	{
		// Token: 0x060135CF RID: 79311 RVA: 0x005C385B File Offset: 0x005C1C5B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node98()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x060135D0 RID: 79312 RVA: 0x005C3878 File Offset: 0x005C1C78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D01E RID: 53278
		private BE_Target opl_p0;

		// Token: 0x0400D01F RID: 53279
		private BE_Equal opl_p1;

		// Token: 0x0400D020 RID: 53280
		private BE_State opl_p2;
	}
}
