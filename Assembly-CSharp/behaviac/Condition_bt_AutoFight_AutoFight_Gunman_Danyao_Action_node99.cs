using System;

namespace behaviac
{
	// Token: 0x020025B2 RID: 9650
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node99 : Condition
	{
		// Token: 0x060134AB RID: 79019 RVA: 0x005BC87B File Offset: 0x005BAC7B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node99()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130202;
		}

		// Token: 0x060134AC RID: 79020 RVA: 0x005BC89C File Offset: 0x005BAC9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEE0 RID: 52960
		private BE_Target opl_p0;

		// Token: 0x0400CEE1 RID: 52961
		private BE_Equal opl_p1;

		// Token: 0x0400CEE2 RID: 52962
		private int opl_p2;
	}
}
