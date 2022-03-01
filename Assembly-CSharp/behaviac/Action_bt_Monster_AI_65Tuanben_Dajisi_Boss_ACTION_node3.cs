using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D6A RID: 11626
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node3 : Action
	{
		// Token: 0x060143B6 RID: 82870 RVA: 0x00613FA8 File Offset: 0x006123A8
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node3()
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
			item.skillID = 21608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143B7 RID: 82871 RVA: 0x00614038 File Offset: 0x00612438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD7F RID: 56703
		private List<Input> method_p0;

		// Token: 0x0400DD80 RID: 56704
		private bool method_p1;
	}
}
