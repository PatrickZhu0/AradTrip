using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002EED RID: 12013
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node3 : Action
	{
		// Token: 0x060146B4 RID: 83636 RVA: 0x006235B0 File Offset: 0x006219B0
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node3()
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
			item.skillID = 21590;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060146B5 RID: 83637 RVA: 0x00623640 File Offset: 0x00621A40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E030 RID: 57392
		private List<Input> method_p0;

		// Token: 0x0400E031 RID: 57393
		private bool method_p1;
	}
}
