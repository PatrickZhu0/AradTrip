using System;

namespace behaviac
{
	// Token: 0x020025AD RID: 9645
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node55 : Condition
	{
		// Token: 0x060134A1 RID: 79009 RVA: 0x005BC666 File Offset: 0x005BAA66
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node55()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060134A2 RID: 79010 RVA: 0x005BC69C File Offset: 0x005BAA9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CED5 RID: 52949
		private int opl_p0;

		// Token: 0x0400CED6 RID: 52950
		private int opl_p1;

		// Token: 0x0400CED7 RID: 52951
		private int opl_p2;

		// Token: 0x0400CED8 RID: 52952
		private int opl_p3;
	}
}
