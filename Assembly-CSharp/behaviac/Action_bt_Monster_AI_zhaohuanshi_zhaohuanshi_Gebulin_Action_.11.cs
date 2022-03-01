using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FB8 RID: 16312
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node58 : Action
	{
		// Token: 0x060166DA RID: 91866 RVA: 0x006C88A8 File Offset: 0x006C6CA8
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node58()
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
			item.skillID = 5111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060166DB RID: 91867 RVA: 0x006C8938 File Offset: 0x006C6D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF2D RID: 65325
		private List<Input> method_p0;

		// Token: 0x0400FF2E RID: 65326
		private bool method_p1;
	}
}
