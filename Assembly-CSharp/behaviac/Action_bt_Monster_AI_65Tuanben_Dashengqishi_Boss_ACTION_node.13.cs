using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DAE RID: 11694
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node8 : Action
	{
		// Token: 0x0601443D RID: 83005 RVA: 0x00616394 File Offset: 0x00614794
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node8()
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
			item.skillID = 21644;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601443E RID: 83006 RVA: 0x00616424 File Offset: 0x00614824
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE03 RID: 56835
		private List<Input> method_p0;

		// Token: 0x0400DE04 RID: 56836
		private bool method_p1;
	}
}
