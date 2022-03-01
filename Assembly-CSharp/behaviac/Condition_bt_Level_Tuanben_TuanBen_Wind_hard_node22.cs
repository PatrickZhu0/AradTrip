using System;

namespace behaviac
{
	// Token: 0x02002B1C RID: 11036
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node22 : Condition
	{
		// Token: 0x06013F4B RID: 81739 RVA: 0x005FD6E8 File Offset: 0x005FBAE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((LevelAgent)pAgent).Condition_RoomRunningTime();
			int num2 = 1;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
