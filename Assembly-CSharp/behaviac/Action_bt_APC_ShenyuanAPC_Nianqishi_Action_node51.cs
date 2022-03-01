using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EB1 RID: 7857
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node51 : Action
	{
		// Token: 0x0601270A RID: 75530 RVA: 0x00564B54 File Offset: 0x00562F54
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_node51()
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

		// Token: 0x0601270B RID: 75531 RVA: 0x00564BE4 File Offset: 0x00562FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0F7 RID: 49399
		private List<Input> method_p0;

		// Token: 0x0400C0F8 RID: 49400
		private bool method_p1;
	}
}
