using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EE5 RID: 12005
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node6 : Action
	{
		// Token: 0x060146A4 RID: 83620 RVA: 0x00623218 File Offset: 0x00621618
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node6()
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
			item.skillID = 21591;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146A5 RID: 83621 RVA: 0x006232A8 File Offset: 0x006216A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E01C RID: 57372
		private List<Input> method_p0;

		// Token: 0x0400E01D RID: 57373
		private bool method_p1;
	}
}
