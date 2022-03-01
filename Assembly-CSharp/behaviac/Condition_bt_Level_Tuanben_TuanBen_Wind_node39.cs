using System;

namespace behaviac
{
	// Token: 0x02002AF1 RID: 10993
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node39 : Condition
	{
		// Token: 0x06013EF6 RID: 81654 RVA: 0x005FC11E File Offset: 0x005FA51E
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node39()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06013EF7 RID: 81655 RVA: 0x005FC130 File Offset: 0x005FA530
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D94E RID: 55630
		private int opl_p0;
	}
}
