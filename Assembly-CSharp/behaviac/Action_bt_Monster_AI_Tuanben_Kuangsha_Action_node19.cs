using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AD6 RID: 15062
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node19 : Action
	{
		// Token: 0x06015D6B RID: 89451 RVA: 0x00698D04 File Offset: 0x00697104
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node19()
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
			item.skillID = 21031;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D6C RID: 89452 RVA: 0x00698D94 File Offset: 0x00697194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F679 RID: 63097
		private List<Input> method_p0;

		// Token: 0x0400F67A RID: 63098
		private bool method_p1;
	}
}
