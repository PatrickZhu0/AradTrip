using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200371B RID: 14107
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6 : Action
	{
		// Token: 0x06015643 RID: 87619 RVA: 0x00674300 File Offset: 0x00672700
		public Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6()
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
			item.skillID = 5310;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015644 RID: 87620 RVA: 0x00674390 File Offset: 0x00672790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F00F RID: 61455
		private List<Input> method_p0;

		// Token: 0x0400F010 RID: 61456
		private bool method_p1;
	}
}
