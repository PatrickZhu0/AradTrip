using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F07 RID: 12039
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8 : Action
	{
		// Token: 0x060146E5 RID: 83685 RVA: 0x006255F4 File Offset: 0x006239F4
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8()
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
			item.skillID = 21614;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146E6 RID: 83686 RVA: 0x00625684 File Offset: 0x00623A84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E05E RID: 57438
		private List<Input> method_p0;

		// Token: 0x0400E05F RID: 57439
		private bool method_p1;
	}
}
