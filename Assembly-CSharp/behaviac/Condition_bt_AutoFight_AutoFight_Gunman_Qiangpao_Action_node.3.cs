using System;

namespace behaviac
{
	// Token: 0x02002640 RID: 9792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node92 : Condition
	{
		// Token: 0x060135C5 RID: 79301 RVA: 0x005C364B File Offset: 0x005C1A4B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node92()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x060135C6 RID: 79302 RVA: 0x005C3668 File Offset: 0x005C1A68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D013 RID: 53267
		private BE_Target opl_p0;

		// Token: 0x0400D014 RID: 53268
		private BE_Equal opl_p1;

		// Token: 0x0400D015 RID: 53269
		private BE_State opl_p2;
	}
}
