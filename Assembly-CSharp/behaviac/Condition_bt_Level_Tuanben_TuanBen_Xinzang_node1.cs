using System;

namespace behaviac
{
	// Token: 0x02002B2C RID: 11052
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Xinzang_node1 : Condition
	{
		// Token: 0x06013F69 RID: 81769 RVA: 0x005FE64A File Offset: 0x005FCA4A
		public Condition_bt_Level_Tuanben_TuanBen_Xinzang_node1()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06013F6A RID: 81770 RVA: 0x005FE65C File Offset: 0x005FCA5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A2 RID: 55714
		private int opl_p0;
	}
}
