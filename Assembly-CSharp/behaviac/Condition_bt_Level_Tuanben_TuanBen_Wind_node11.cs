using System;

namespace behaviac
{
	// Token: 0x02002AFD RID: 11005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node11 : Condition
	{
		// Token: 0x06013F0E RID: 81678 RVA: 0x005FC3F2 File Offset: 0x005FA7F2
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node11()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x06013F0F RID: 81679 RVA: 0x005FC404 File Offset: 0x005FA804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D95E RID: 55646
		private int opl_p0;
	}
}
