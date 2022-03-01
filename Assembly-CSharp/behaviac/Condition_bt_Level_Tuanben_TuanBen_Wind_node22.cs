using System;

namespace behaviac
{
	// Token: 0x02002AFE RID: 11006
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node22 : Condition
	{
		// Token: 0x06013F11 RID: 81681 RVA: 0x005FC440 File Offset: 0x005FA840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((LevelAgent)pAgent).Condition_RoomRunningTime();
			int num2 = 1;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
