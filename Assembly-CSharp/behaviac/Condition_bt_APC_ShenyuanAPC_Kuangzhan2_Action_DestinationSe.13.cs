using System;

namespace behaviac
{
	// Token: 0x02001E83 RID: 7811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node8 : Condition
	{
		// Token: 0x060126B1 RID: 75441 RVA: 0x005629A8 File Offset: 0x00560DA8
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180000;
		}

		// Token: 0x060126B2 RID: 75442 RVA: 0x005629CC File Offset: 0x00560DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C09A RID: 49306
		private BE_Target opl_p0;

		// Token: 0x0400C09B RID: 49307
		private BE_Equal opl_p1;

		// Token: 0x0400C09C RID: 49308
		private int opl_p2;
	}
}
