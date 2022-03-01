using System;

namespace behaviac
{
	// Token: 0x02002AE6 RID: 10982
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2 : Condition
	{
		// Token: 0x06013EE3 RID: 81635 RVA: 0x005FB6EA File Offset: 0x005F9AEA
		public Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06013EE4 RID: 81636 RVA: 0x005FB6FC File Offset: 0x005F9AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D94A RID: 55626
		private int opl_p0;
	}
}
