using System;

namespace behaviac
{
	// Token: 0x02002B9F RID: 11167
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node3 : Condition
	{
		// Token: 0x06014047 RID: 81991 RVA: 0x006030CB File Offset: 0x006014CB
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node3()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = true;
			this.opl_p2 = false;
		}

		// Token: 0x06014048 RID: 81992 RVA: 0x006030EC File Offset: 0x006014EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsAroundHorizontalEdge(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA3F RID: 55871
		private int opl_p0;

		// Token: 0x0400DA40 RID: 55872
		private bool opl_p1;

		// Token: 0x0400DA41 RID: 55873
		private bool opl_p2;
	}
}
