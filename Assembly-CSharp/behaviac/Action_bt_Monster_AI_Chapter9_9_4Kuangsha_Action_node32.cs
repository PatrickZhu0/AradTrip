using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200318A RID: 12682
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node32 : Action
	{
		// Token: 0x06014BAB RID: 84907 RVA: 0x0063DB4C File Offset: 0x0063BF4C
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node32()
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
			item.skillID = 21544;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014BAC RID: 84908 RVA: 0x0063DBDC File Offset: 0x0063BFDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E518 RID: 58648
		private List<Input> method_p0;

		// Token: 0x0400E519 RID: 58649
		private bool method_p1;
	}
}
