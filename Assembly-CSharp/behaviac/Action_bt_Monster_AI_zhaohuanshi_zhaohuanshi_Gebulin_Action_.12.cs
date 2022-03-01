using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FBC RID: 16316
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node63 : Action
	{
		// Token: 0x060166E2 RID: 91874 RVA: 0x006C8A5C File Offset: 0x006C6E5C
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node63()
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
			item.skillID = 5110;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060166E3 RID: 91875 RVA: 0x006C8AEC File Offset: 0x006C6EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF35 RID: 65333
		private List<Input> method_p0;

		// Token: 0x0400FF36 RID: 65334
		private bool method_p1;
	}
}
