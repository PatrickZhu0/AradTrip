using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B8A RID: 11146
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node0 : Action
	{
		// Token: 0x06014020 RID: 81952 RVA: 0x00602040 File Offset: 0x00600440
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node0()
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
			item.skillID = 20763;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014021 RID: 81953 RVA: 0x006020D0 File Offset: 0x006004D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA18 RID: 55832
		private List<Input> method_p0;

		// Token: 0x0400DA19 RID: 55833
		private bool method_p1;
	}
}
