using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EC8 RID: 11976
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node24 : Action
	{
		// Token: 0x0601466A RID: 83562 RVA: 0x006225EC File Offset: 0x006209EC
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node24()
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
			item.skillID = 21598;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601466B RID: 83563 RVA: 0x0062267C File Offset: 0x00620A7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFD4 RID: 57300
		private List<Input> method_p0;

		// Token: 0x0400DFD5 RID: 57301
		private bool method_p1;
	}
}
