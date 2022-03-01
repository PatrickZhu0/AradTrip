using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036C7 RID: 14023
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4 : Action
	{
		// Token: 0x060155A6 RID: 87462 RVA: 0x00671140 File Offset: 0x0066F540
		public Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node4()
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
			item.skillID = 5434;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155A7 RID: 87463 RVA: 0x006711D0 File Offset: 0x0066F5D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF78 RID: 61304
		private List<Input> method_p0;

		// Token: 0x0400EF79 RID: 61305
		private bool method_p1;
	}
}
