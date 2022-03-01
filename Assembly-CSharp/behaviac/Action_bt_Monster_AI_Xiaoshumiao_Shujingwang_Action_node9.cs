using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E0C RID: 15884
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node9 : Action
	{
		// Token: 0x060163A1 RID: 91041 RVA: 0x006B8308 File Offset: 0x006B6708
		public Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node9()
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
			item.skillID = 7240;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163A2 RID: 91042 RVA: 0x006B8398 File Offset: 0x006B6798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC07 RID: 64519
		private List<Input> method_p0;

		// Token: 0x0400FC08 RID: 64520
		private bool method_p1;
	}
}
