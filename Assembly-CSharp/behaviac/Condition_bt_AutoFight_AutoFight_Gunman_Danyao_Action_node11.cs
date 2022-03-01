using System;

namespace behaviac
{
	// Token: 0x020025CC RID: 9676
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node110 : Condition
	{
		// Token: 0x060134DF RID: 79071 RVA: 0x005BD30B File Offset: 0x005BB70B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node110()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130304;
		}

		// Token: 0x060134E0 RID: 79072 RVA: 0x005BD32C File Offset: 0x005BB72C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF1E RID: 53022
		private BE_Target opl_p0;

		// Token: 0x0400CF1F RID: 53023
		private BE_Equal opl_p1;

		// Token: 0x0400CF20 RID: 53024
		private int opl_p2;
	}
}
