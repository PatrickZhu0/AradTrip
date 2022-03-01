using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036C2 RID: 14018
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node9 : Action
	{
		// Token: 0x0601559D RID: 87453 RVA: 0x00670D20 File Offset: 0x0066F120
		public Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node9()
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
			item.skillID = 5330;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601559E RID: 87454 RVA: 0x00670DB0 File Offset: 0x0066F1B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF6F RID: 61295
		private List<Input> method_p0;

		// Token: 0x0400EF70 RID: 61296
		private bool method_p1;
	}
}
