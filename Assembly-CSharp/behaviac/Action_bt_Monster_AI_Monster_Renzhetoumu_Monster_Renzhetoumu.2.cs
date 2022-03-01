using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036EC RID: 14060
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node5 : Action
	{
		// Token: 0x060155EC RID: 87532 RVA: 0x00672964 File Offset: 0x00670D64
		public Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node5()
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
			item.skillID = 7274;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155ED RID: 87533 RVA: 0x006729F4 File Offset: 0x00670DF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFBE RID: 61374
		private List<Input> method_p0;

		// Token: 0x0400EFBF RID: 61375
		private bool method_p1;
	}
}
