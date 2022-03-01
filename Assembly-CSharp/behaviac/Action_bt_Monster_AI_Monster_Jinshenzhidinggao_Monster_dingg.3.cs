using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003690 RID: 13968
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node10 : Action
	{
		// Token: 0x0601553E RID: 87358 RVA: 0x0066ECFC File Offset: 0x0066D0FC
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node10()
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
			item.skillID = 5630;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601553F RID: 87359 RVA: 0x0066ED8C File Offset: 0x0066D18C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF00 RID: 61184
		private List<Input> method_p0;

		// Token: 0x0400EF01 RID: 61185
		private bool method_p1;
	}
}
