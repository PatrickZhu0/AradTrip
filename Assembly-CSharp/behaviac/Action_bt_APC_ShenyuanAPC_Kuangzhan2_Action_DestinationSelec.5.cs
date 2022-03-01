using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E85 RID: 7813
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node7 : Action
	{
		// Token: 0x060126B5 RID: 75445 RVA: 0x00562A54 File Offset: 0x00560E54
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 9704;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126B6 RID: 75446 RVA: 0x00562AE4 File Offset: 0x00560EE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C09E RID: 49310
		private List<Input> method_p0;

		// Token: 0x0400C09F RID: 49311
		private bool method_p1;
	}
}
