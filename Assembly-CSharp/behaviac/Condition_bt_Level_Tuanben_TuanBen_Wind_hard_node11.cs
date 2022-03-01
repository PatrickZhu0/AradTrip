using System;

namespace behaviac
{
	// Token: 0x02002B1B RID: 11035
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node11 : Condition
	{
		// Token: 0x06013F48 RID: 81736 RVA: 0x005FD69A File Offset: 0x005FBA9A
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node11()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x06013F49 RID: 81737 RVA: 0x005FD6AC File Offset: 0x005FBAAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D988 RID: 55688
		private int opl_p0;
	}
}
