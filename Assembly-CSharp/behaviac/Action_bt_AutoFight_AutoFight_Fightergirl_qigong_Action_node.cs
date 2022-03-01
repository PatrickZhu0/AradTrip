using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EF5 RID: 7925
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node8 : Action
	{
		// Token: 0x0601278E RID: 75662 RVA: 0x00567B48 File Offset: 0x00565F48
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node8()
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
			item.skillID = 3100;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601278F RID: 75663 RVA: 0x00567BD8 File Offset: 0x00565FD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C183 RID: 49539
		private List<Input> method_p0;

		// Token: 0x0400C184 RID: 49540
		private bool method_p1;
	}
}
