using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AD1 RID: 15057
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node53 : Action
	{
		// Token: 0x06015D61 RID: 89441 RVA: 0x00698AF0 File Offset: 0x00696EF0
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node53()
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
			item.skillID = 21030;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D62 RID: 89442 RVA: 0x00698B80 File Offset: 0x00696F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F66E RID: 63086
		private List<Input> method_p0;

		// Token: 0x0400F66F RID: 63087
		private bool method_p1;
	}
}
