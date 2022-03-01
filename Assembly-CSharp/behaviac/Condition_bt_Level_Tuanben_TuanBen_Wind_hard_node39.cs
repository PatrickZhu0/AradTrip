using System;

namespace behaviac
{
	// Token: 0x02002B0F RID: 11023
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node39 : Condition
	{
		// Token: 0x06013F30 RID: 81712 RVA: 0x005FD3C6 File Offset: 0x005FB7C6
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node39()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06013F31 RID: 81713 RVA: 0x005FD3D8 File Offset: 0x005FB7D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_IsInRoom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D978 RID: 55672
		private int opl_p0;
	}
}
