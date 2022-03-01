using System;

namespace behaviac
{
	// Token: 0x02002E3D RID: 11837
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node82 : Condition
	{
		// Token: 0x06014557 RID: 83287 RVA: 0x0061ABEE File Offset: 0x00618FEE
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node82()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06014558 RID: 83288 RVA: 0x0061AC00 File Offset: 0x00619000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEEE RID: 57070
		private int opl_p0;
	}
}
