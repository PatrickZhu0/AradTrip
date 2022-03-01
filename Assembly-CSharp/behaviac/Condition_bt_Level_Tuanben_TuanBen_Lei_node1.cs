using System;

namespace behaviac
{
	// Token: 0x02002AEB RID: 10987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Lei_node1 : Condition
	{
		// Token: 0x06013EEC RID: 81644 RVA: 0x005FB8FA File Offset: 0x005F9CFA
		public Condition_bt_Level_Tuanben_TuanBen_Lei_node1()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06013EED RID: 81645 RVA: 0x005FB90C File Offset: 0x005F9D0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D94C RID: 55628
		private int opl_p0;
	}
}
