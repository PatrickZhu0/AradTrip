using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200370E RID: 14094
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node6 : Action
	{
		// Token: 0x0601562A RID: 87594 RVA: 0x00673B08 File Offset: 0x00671F08
		public Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node6()
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
			item.skillID = 5284;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601562B RID: 87595 RVA: 0x00673B98 File Offset: 0x00671F98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFF3 RID: 61427
		private List<Input> method_p0;

		// Token: 0x0400EFF4 RID: 61428
		private bool method_p1;
	}
}
