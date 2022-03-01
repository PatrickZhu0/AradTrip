using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003605 RID: 13829
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5 : Action
	{
		// Token: 0x06015430 RID: 87088 RVA: 0x00668994 File Offset: 0x00666D94
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5()
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
			item.skillID = 5440;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015431 RID: 87089 RVA: 0x00668A24 File Offset: 0x00666E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDE8 RID: 60904
		private List<Input> method_p0;

		// Token: 0x0400EDE9 RID: 60905
		private bool method_p1;
	}
}
