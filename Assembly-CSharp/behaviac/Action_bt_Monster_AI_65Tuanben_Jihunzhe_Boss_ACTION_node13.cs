using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F0F RID: 12047
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13 : Action
	{
		// Token: 0x060146F5 RID: 83701 RVA: 0x00625910 File Offset: 0x00623D10
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13()
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
			item.skillID = 21615;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146F6 RID: 83702 RVA: 0x006259A0 File Offset: 0x00623DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E06C RID: 57452
		private List<Input> method_p0;

		// Token: 0x0400E06D RID: 57453
		private bool method_p1;
	}
}
