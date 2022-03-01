using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DE8 RID: 11752
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node25 : Action
	{
		// Token: 0x060144AD RID: 83117 RVA: 0x00618B50 File Offset: 0x00616F50
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node25()
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
			item.skillID = 21626;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060144AE RID: 83118 RVA: 0x00618BE0 File Offset: 0x00616FE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE64 RID: 56932
		private List<Input> method_p0;

		// Token: 0x0400DE65 RID: 56933
		private bool method_p1;
	}
}
