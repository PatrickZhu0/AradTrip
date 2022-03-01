using System;

namespace behaviac
{
	// Token: 0x02002ADE RID: 10974
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node6 : Condition
	{
		// Token: 0x06013ED4 RID: 81620 RVA: 0x005FB1A4 File Offset: 0x005F95A4
		public Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node6()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = -1;
		}

		// Token: 0x06013ED5 RID: 81621 RVA: 0x005FB1BC File Offset: 0x005F95BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D940 RID: 55616
		private LevelCounterType opl_p0;

		// Token: 0x0400D941 RID: 55617
		private int opl_p1;
	}
}
