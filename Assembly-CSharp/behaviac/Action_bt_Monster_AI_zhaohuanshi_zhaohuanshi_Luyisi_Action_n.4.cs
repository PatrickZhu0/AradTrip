using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FDB RID: 16347
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7 : Action
	{
		// Token: 0x0601671E RID: 91934 RVA: 0x006CA934 File Offset: 0x006C8D34
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7()
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
			item.skillID = 5021;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601671F RID: 91935 RVA: 0x006CA9C4 File Offset: 0x006C8DC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF71 RID: 65393
		private List<Input> method_p0;

		// Token: 0x0400FF72 RID: 65394
		private bool method_p1;
	}
}
