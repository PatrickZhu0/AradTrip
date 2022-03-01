using System;

namespace behaviac
{
	// Token: 0x02002B36 RID: 11062
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node1 : Condition
	{
		// Token: 0x06013F7B RID: 81787 RVA: 0x005FEA6E File Offset: 0x005FCE6E
		public Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node1()
		{
			this.opl_p0 = 87300031;
		}

		// Token: 0x06013F7C RID: 81788 RVA: 0x005FEA84 File Offset: 0x005FCE84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_HaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A6 RID: 55718
		private int opl_p0;
	}
}
