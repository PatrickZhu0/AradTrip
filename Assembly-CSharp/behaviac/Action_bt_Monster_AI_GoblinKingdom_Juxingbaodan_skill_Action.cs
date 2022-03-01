using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200339A RID: 13210
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node12 : Action
	{
		// Token: 0x06014F8F RID: 85903 RVA: 0x006519C0 File Offset: 0x0064FDC0
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node12()
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
			item.skillID = 5803;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014F90 RID: 85904 RVA: 0x00651A50 File Offset: 0x0064FE50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E86A RID: 59498
		private List<Input> method_p0;

		// Token: 0x0400E86B RID: 59499
		private bool method_p1;
	}
}
