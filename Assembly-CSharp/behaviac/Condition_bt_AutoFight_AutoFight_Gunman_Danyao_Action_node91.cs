using System;

namespace behaviac
{
	// Token: 0x02002597 RID: 9623
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node91 : Condition
	{
		// Token: 0x06013475 RID: 78965 RVA: 0x005BBD57 File Offset: 0x005BA157
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node91()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130203;
		}

		// Token: 0x06013476 RID: 78966 RVA: 0x005BBD78 File Offset: 0x005BA178
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEA3 RID: 52899
		private BE_Target opl_p0;

		// Token: 0x0400CEA4 RID: 52900
		private BE_Equal opl_p1;

		// Token: 0x0400CEA5 RID: 52901
		private int opl_p2;
	}
}
