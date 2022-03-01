using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D7D RID: 11645
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node36 : Action
	{
		// Token: 0x060143DC RID: 82908 RVA: 0x00614718 File Offset: 0x00612B18
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node36()
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
			item.skillID = 21607;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143DD RID: 82909 RVA: 0x006147A8 File Offset: 0x00612BA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDAB RID: 56747
		private List<Input> method_p0;

		// Token: 0x0400DDAC RID: 56748
		private bool method_p1;
	}
}
