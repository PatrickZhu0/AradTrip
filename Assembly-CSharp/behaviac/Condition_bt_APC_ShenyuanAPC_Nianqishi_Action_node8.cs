using System;

namespace behaviac
{
	// Token: 0x02001EBB RID: 7867
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node8 : Condition
	{
		// Token: 0x0601271E RID: 75550 RVA: 0x00564FE4 File Offset: 0x005633E4
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180000;
		}

		// Token: 0x0601271F RID: 75551 RVA: 0x00565008 File Offset: 0x00563408
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C10D RID: 49421
		private BE_Target opl_p0;

		// Token: 0x0400C10E RID: 49422
		private BE_Equal opl_p1;

		// Token: 0x0400C10F RID: 49423
		private int opl_p2;
	}
}
