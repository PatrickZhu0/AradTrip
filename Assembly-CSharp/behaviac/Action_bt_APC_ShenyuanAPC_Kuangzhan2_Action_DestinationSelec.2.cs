using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E79 RID: 7801
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node51 : Action
	{
		// Token: 0x0601269D RID: 75421 RVA: 0x0056251C File Offset: 0x0056091C
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node51()
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
			item.skillID = 9701;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601269E RID: 75422 RVA: 0x005625AC File Offset: 0x005609AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C084 RID: 49284
		private List<Input> method_p0;

		// Token: 0x0400C085 RID: 49285
		private bool method_p1;
	}
}
