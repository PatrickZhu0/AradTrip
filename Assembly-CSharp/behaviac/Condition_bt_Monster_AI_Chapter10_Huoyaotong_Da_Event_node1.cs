using System;

namespace behaviac
{
	// Token: 0x0200310F RID: 12559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Da_Event_node1 : Condition
	{
		// Token: 0x06014AC8 RID: 84680 RVA: 0x00639CA8 File Offset: 0x006380A8
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Da_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522064;
		}

		// Token: 0x06014AC9 RID: 84681 RVA: 0x00639CCC File Offset: 0x006380CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E437 RID: 58423
		private BE_Target opl_p0;

		// Token: 0x0400E438 RID: 58424
		private BE_Equal opl_p1;

		// Token: 0x0400E439 RID: 58425
		private int opl_p2;
	}
}
