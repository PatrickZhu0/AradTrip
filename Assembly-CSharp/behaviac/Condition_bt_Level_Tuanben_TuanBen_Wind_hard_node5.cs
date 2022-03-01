using System;

namespace behaviac
{
	// Token: 0x02002B12 RID: 11026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node5 : Condition
	{
		// Token: 0x06013F36 RID: 81718 RVA: 0x005FD467 File Offset: 0x005FB867
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node5()
		{
			this.opl_p0 = 20;
		}

		// Token: 0x06013F37 RID: 81719 RVA: 0x005FD478 File Offset: 0x005FB878
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCountTime(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D97A RID: 55674
		private int opl_p0;
	}
}
