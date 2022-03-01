using System;

namespace behaviac
{
	// Token: 0x02002AFB RID: 11003
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node12 : Condition
	{
		// Token: 0x06013F0A RID: 81674 RVA: 0x005FC372 File Offset: 0x005FA772
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node12()
		{
			this.opl_p0 = 450;
		}

		// Token: 0x06013F0B RID: 81675 RVA: 0x005FC388 File Offset: 0x005FA788
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D95B RID: 55643
		private int opl_p0;
	}
}
