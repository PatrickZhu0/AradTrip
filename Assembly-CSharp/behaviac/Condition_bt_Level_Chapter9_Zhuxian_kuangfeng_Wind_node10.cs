using System;

namespace behaviac
{
	// Token: 0x02002AE0 RID: 10976
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node10 : Condition
	{
		// Token: 0x06013ED8 RID: 81624 RVA: 0x005FB22F File Offset: 0x005F962F
		public Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node10()
		{
			this.opl_p0 = 450;
		}

		// Token: 0x06013ED9 RID: 81625 RVA: 0x005FB244 File Offset: 0x005F9644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D944 RID: 55620
		private int opl_p0;
	}
}
