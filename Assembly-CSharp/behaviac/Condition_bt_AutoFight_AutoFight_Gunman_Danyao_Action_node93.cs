using System;

namespace behaviac
{
	// Token: 0x02002599 RID: 9625
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node93 : Condition
	{
		// Token: 0x06013479 RID: 78969 RVA: 0x005BBE17 File Offset: 0x005BA217
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node93()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130301;
		}

		// Token: 0x0601347A RID: 78970 RVA: 0x005BBE38 File Offset: 0x005BA238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEA9 RID: 52905
		private BE_Target opl_p0;

		// Token: 0x0400CEAA RID: 52906
		private BE_Equal opl_p1;

		// Token: 0x0400CEAB RID: 52907
		private int opl_p2;
	}
}
