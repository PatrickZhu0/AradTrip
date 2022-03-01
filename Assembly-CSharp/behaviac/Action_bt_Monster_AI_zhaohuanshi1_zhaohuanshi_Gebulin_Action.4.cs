using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004045 RID: 16453
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node23 : Action
	{
		// Token: 0x060167E9 RID: 92137 RVA: 0x006CEE98 File Offset: 0x006CD298
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node23()
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
			item.skillID = 5108;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060167EA RID: 92138 RVA: 0x006CEF28 File Offset: 0x006CD328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010034 RID: 65588
		private List<Input> method_p0;

		// Token: 0x04010035 RID: 65589
		private bool method_p1;
	}
}
