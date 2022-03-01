using System;

namespace behaviac
{
	// Token: 0x0200259B RID: 9627
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node95 : Condition
	{
		// Token: 0x0601347D RID: 78973 RVA: 0x005BBED7 File Offset: 0x005BA2D7
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node95()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130303;
		}

		// Token: 0x0601347E RID: 78974 RVA: 0x005BBEF8 File Offset: 0x005BA2F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEAF RID: 52911
		private BE_Target opl_p0;

		// Token: 0x0400CEB0 RID: 52912
		private BE_Equal opl_p1;

		// Token: 0x0400CEB1 RID: 52913
		private int opl_p2;
	}
}
