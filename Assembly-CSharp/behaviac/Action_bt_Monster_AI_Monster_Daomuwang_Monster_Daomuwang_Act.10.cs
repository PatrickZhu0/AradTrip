using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003644 RID: 13892
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node10 : Action
	{
		// Token: 0x060154AB RID: 87211 RVA: 0x0066B684 File Offset: 0x00669A84
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node10()
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
			item.skillID = 5425;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154AC RID: 87212 RVA: 0x0066B714 File Offset: 0x00669B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE63 RID: 61027
		private List<Input> method_p0;

		// Token: 0x0400EE64 RID: 61028
		private bool method_p1;
	}
}
