using System;

namespace behaviac
{
	// Token: 0x02002AE2 RID: 10978
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node12 : Condition
	{
		// Token: 0x06013EDC RID: 81628 RVA: 0x005FB2AE File Offset: 0x005F96AE
		public Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node12()
		{
			this.opl_p0 = 450;
		}

		// Token: 0x06013EDD RID: 81629 RVA: 0x005FB2C4 File Offset: 0x005F96C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D947 RID: 55623
		private int opl_p0;
	}
}
