using System;

namespace behaviac
{
	// Token: 0x020025CA RID: 9674
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node108 : Condition
	{
		// Token: 0x060134DB RID: 79067 RVA: 0x005BD24B File Offset: 0x005BB64B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node108()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130302;
		}

		// Token: 0x060134DC RID: 79068 RVA: 0x005BD26C File Offset: 0x005BB66C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF18 RID: 53016
		private BE_Target opl_p0;

		// Token: 0x0400CF19 RID: 53017
		private BE_Equal opl_p1;

		// Token: 0x0400CF1A RID: 53018
		private int opl_p2;
	}
}
