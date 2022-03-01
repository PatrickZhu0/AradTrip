using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003FF5 RID: 16373
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node17 : Action
	{
		// Token: 0x06016750 RID: 91984 RVA: 0x006CBAF8 File Offset: 0x006C9EF8
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node17()
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
			item.skillID = 5355;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016751 RID: 91985 RVA: 0x006CBB88 File Offset: 0x006C9F88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFA1 RID: 65441
		private List<Input> method_p0;

		// Token: 0x0400FFA2 RID: 65442
		private bool method_p1;
	}
}
