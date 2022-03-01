using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E20 RID: 15904
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node8 : Action
	{
		// Token: 0x060163C8 RID: 91080 RVA: 0x006B9178 File Offset: 0x006B7578
		public Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node8()
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
			item.skillID = 9757;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163C9 RID: 91081 RVA: 0x006B9208 File Offset: 0x006B7608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC2F RID: 64559
		private List<Input> method_p0;

		// Token: 0x0400FC30 RID: 64560
		private bool method_p1;
	}
}
