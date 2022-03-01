using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E10 RID: 15888
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node5 : Action
	{
		// Token: 0x060163A9 RID: 91049 RVA: 0x006B84BC File Offset: 0x006B68BC
		public Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node5()
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
			item.skillID = 5199;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163AA RID: 91050 RVA: 0x006B854C File Offset: 0x006B694C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC0F RID: 64527
		private List<Input> method_p0;

		// Token: 0x0400FC10 RID: 64528
		private bool method_p1;
	}
}
