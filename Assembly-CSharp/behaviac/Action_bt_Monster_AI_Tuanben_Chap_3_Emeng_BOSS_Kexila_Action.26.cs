using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200388A RID: 14474
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node39 : Action
	{
		// Token: 0x060158F8 RID: 88312 RVA: 0x00681A60 File Offset: 0x0067FE60
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node39()
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
			item.skillID = 21213;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060158F9 RID: 88313 RVA: 0x00681AF0 File Offset: 0x0067FEF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F28F RID: 62095
		private List<Input> method_p0;

		// Token: 0x0400F290 RID: 62096
		private bool method_p1;
	}
}
