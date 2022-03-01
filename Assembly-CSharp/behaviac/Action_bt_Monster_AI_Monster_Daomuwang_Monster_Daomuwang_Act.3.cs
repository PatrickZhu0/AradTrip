using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003627 RID: 13863
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node15 : Action
	{
		// Token: 0x06015472 RID: 87154 RVA: 0x0066A304 File Offset: 0x00668704
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node15()
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
			item.skillID = 5429;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015473 RID: 87155 RVA: 0x0066A394 File Offset: 0x00668794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE2B RID: 60971
		private List<Input> method_p0;

		// Token: 0x0400EE2C RID: 60972
		private bool method_p1;
	}
}
