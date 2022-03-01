using System;

namespace behaviac
{
	// Token: 0x02002ADB RID: 10971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5 : Condition
	{
		// Token: 0x06013ECE RID: 81614 RVA: 0x005FB0FA File Offset: 0x005F94FA
		public Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5()
		{
			this.opl_p0 = 20;
		}

		// Token: 0x06013ECF RID: 81615 RVA: 0x005FB10C File Offset: 0x005F950C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCountTime(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D93C RID: 55612
		private int opl_p0;
	}
}
